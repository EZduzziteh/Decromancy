using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

   
  
    public Deck HordeDeck;
    public Deck PowerDeck;
    Hand hand;
    public int hordeSize = 5;
    public int powerSize = 0;
    public float ActiveCardZValue=3.0f;
    public float ActiveCardXValue=5.0f;


    private void Start()
    {

       
        DrawHand();
    }

    // Start is called before the first frame update
    void Awake()
    {
        hand = GetComponent<Hand>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            hand.DeselectAll();
        }
    }


    void DrawHand()
    {
        for (int i = hand.GetHordeCount(); i < hordeSize; i++)//#todo check for horde/power separately
        {
            Card card = HordeDeck.Draw();
            card.hand = hand;
           hand.cards.Add(card);

        }
        /*for (int i = hand.GetPowerCount(); i < hordeSize; i++)//#todo check for horde/power separately
        {
            hand.cards.Add(PowerDeck.Draw());
        }*/

        hand.Display();
    }
}
