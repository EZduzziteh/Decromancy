using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

   
  
    public Deck HordeDeck;
    public Deck PowerDeck;
    public Hand hand;
    public int hordeSize = 5;
    public int powerSize = 0;
    public float ActiveCardZValue=3.0f;
    public float ActiveCardXValue=5.0f;
    public Card ActiveHordeCard;
    public TurnManager.PlayerTurn playerID;
    public TurnManager turnman;

    public bool isAIControlled=true;
    public bool hasDrawn;

    private void Start()
    {

       
       
    }

    // Start is called before the first frame update
    void Awake()
    {
        hand = GetComponent<Hand>();
        turnman = FindObjectOfType<TurnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            hand.DeselectAll();
        }
    }


    public void DrawHand()
    {

        /*for (int i = hand.GetPowerCount(); i < hordeSize; i++)//#todo check for horde/power separately
        {
            hand.cards.Add(PowerDeck.Draw());
        }*/

        StartCoroutine(DrawHandDelayer());
        
    }




    private IEnumerator DrawHandDelayer()
    {
        WaitForSeconds wait = new WaitForSeconds(0.72f);
        for (int i = hand.GetHordeCount(); i < hordeSize; i++)//#todo check for horde/power separately
        {
            Card card = HordeDeck.Draw();
            card.hand = hand;
            hand.cards.Add(card);
            hand.Display();


            yield return wait;

        }
        hasDrawn =true;
    }
}
