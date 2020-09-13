using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
  public enum PlayerTurn
    {
        Player1, Player2
    }

    public enum TurnPhase
    {
        Draw, //draw up to your max horde and power value
        Abilities, //use any abilities that dont have a specified time.
        Declare, //declare active horde
        Power, //use power cards to affect what is on the table
        Combat, //the hordes fight until one dies
        End //refresh everything and start back at abilities stage

    }

    TurnPhase phase;

    public PlayerTurn playerTurn;
    public Player player1;
    public Player player2;

    bool SecondInPhase;
    private void Start()
    {
       SetRandomPlayer();
        foreach(Player player in FindObjectsOfType<Player>())
        {
            if (player.playerID == PlayerTurn.Player1)
            {
                player1 = player;
            }
            else
            {
                player2 = player;
            }
        }
        phase = TurnPhase.Draw;
        if (playerTurn == PlayerTurn.Player1)
        {
            AIHandlePhase(player1);
        }
        else
        {
            AIHandlePhase(player2);

        }
        
    }

    private void Update()
    {
       
    }
    private void SetRandomPlayer()
    {
        int randomnum = UnityEngine.Random.Range(0, 100);

        if (randomnum > 49)
        {
            playerTurn = PlayerTurn.Player1;
        }
        else
        {
            playerTurn = PlayerTurn.Player2;
        }
    }

    public void EndPhase()
    {
       
        Debug.Log("end");
        switch (playerTurn)
        {
            case PlayerTurn.Player1:
                playerTurn = PlayerTurn.Player2;
                break;
            case PlayerTurn.Player2:
                playerTurn = PlayerTurn.Player1;
                break;

        }
        if (SecondInPhase)
        {
            SecondInPhase = false;
            NextPhase();
        }
        else { SecondInPhase = true; }
        StartCoroutine(EndTurnDelay(5.0f));

    }

    private void NextPhase()
    {
        switch (phase)
        {
            case TurnPhase.Draw:
                phase = TurnPhase.Abilities;
                break;
            case TurnPhase.Abilities:
                phase = TurnPhase.Power;
                break;
            case TurnPhase.Power:
                //#TODO if player still has a horde active, skip their declare phase.
                if (player1.ActiveHordeCard.data.GetHealth() <= 0 || player2.ActiveHordeCard.data.GetHealth() <= 0)
                {
                    phase = TurnPhase.Declare;
                }
                else//both hordes fight again
                {
                    phase = TurnPhase.Combat;
                }
                break;
            case TurnPhase.Declare:
                phase = TurnPhase.Combat;
                break;
            case TurnPhase.Combat:

               
                phase = TurnPhase.End;
                break;
            case TurnPhase.End:
                phase = TurnPhase.Abilities;
                break;
        }
    }

    IEnumerator EndTurnDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (playerTurn == PlayerTurn.Player1)
        {
            AIHandlePhase(player1);
        }
        else
        {
            AIHandlePhase(player2);
        }
    }

    void AIHandlePhase(Player player)
    {
        switch (phase)
        {
            case TurnPhase.Draw:
                Debug.Log("Draw phase for" + player.name);
                player.DrawHand();
                EndPhase();
                break;
            case TurnPhase.Abilities:
                Debug.Log("ability phase for" + player.name);
                EndPhase();
                break;
            case TurnPhase.Power:
                Debug.Log("power phase for" + player.name);
                EndPhase();
                break;
            case TurnPhase.Declare:
                Debug.Log("declare phase for" + player.name);
                player.hand.SetActiveHorde(player.hand.GetRandomHorde());
                EndPhase();
                break;
            case TurnPhase.Combat:
                HandleCombat();
                Debug.Log("combat phase for" + player.name);
                EndPhase();
                break;
            case TurnPhase.End:
                Debug.Log("end phase for" + player.name);
                EndPhase();
                break;
        }
    }


    void HandleCombat()
    {
       player2.ActiveHordeCard.data.TakeDamage( player1.ActiveHordeCard.data.GetAttackDamage());
       player1.ActiveHordeCard.data.TakeDamage(player2.ActiveHordeCard.data.GetAttackDamage());
    }

 
}
