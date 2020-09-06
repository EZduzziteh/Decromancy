using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{

    public List<Card> cards =new List<Card>();
    public GameObject HandPoint;
    public GameObject ActiveHordePoint;
    public float distanceBetweenCardsX=2.8f;
    public float distanceBetweenCardsZ=2.0f;
    public float distanceBetweenCardsY = 0.25f;
    public float rotationBetweenCards;
    public Player player;
    public Card SelectedCard;
    void Awake()
    {

        player = GetComponent<Player>();
    }
    public void Display()
    {
       
        if (cards.Count % 2 == 1)//if uneven place initial card in the middle
        {
            cards[0].transform.position = HandPoint.transform.position;
            cards[0].posInHand = cards[0].transform.position;
            cards[0].rotInHand = cards[0].transform.rotation;

        }

        int cardDistanceMultiplier = 1;
        bool placedCard = false;
        for (int i=cards.Count-1; i > 0; i--)
        {
            //place card on left slot
            //place card on right slot
            //repeat previous 2 steps until done.

            
            if (i % 2==1)//if uneven place left
            {
                cards[i].transform.position = new Vector3(HandPoint.transform.position.x - distanceBetweenCardsX * cardDistanceMultiplier, HandPoint.transform.position.y - distanceBetweenCardsY * cardDistanceMultiplier, HandPoint.transform.position.z - distanceBetweenCardsZ * cardDistanceMultiplier);
                cards[i].transform.Rotate(0, rotationBetweenCards * -cardDistanceMultiplier,0);
                if (!placedCard)
                {
                    placedCard = true;
                }
                else
                {
                    placedCard = false;
                    cardDistanceMultiplier++;
                }
            }
            else//if even place right
            {
                cards[i].transform.position = new Vector3(HandPoint.transform.position.x + distanceBetweenCardsX * cardDistanceMultiplier, HandPoint.transform.position.y-distanceBetweenCardsY*cardDistanceMultiplier , HandPoint.transform.position.z - distanceBetweenCardsZ * cardDistanceMultiplier);
                cards[i].transform.Rotate(0, rotationBetweenCards * cardDistanceMultiplier,0);
                if (!placedCard)
                {
                    placedCard = true;
                }
                else
                {
                    placedCard = false;
                    cardDistanceMultiplier++;
                }
            }

            cards[i].posInHand = cards[i].transform.position;
            cards[i].rotInHand = cards[i].transform.rotation;
        }

           
        



    }
    public void DeselectAll()
    {
        foreach(Card card in cards)
        {
            card.selected = false;
            card.transform.position = card.posInHand;
            card.transform.rotation = card.rotInHand;
            card.GetComponent<Collider>().enabled = true;
        }
        SelectedCard = null;
    }
    public int GetHordeCount()
    {
        int hordeCount=0;
        foreach(Card card in cards)
        {
            if (card.data.cardtype == CardData.CardType.Horde)
            {
                hordeCount++;
            }
        }
        return hordeCount;
       
    }
    public int GetPowerCount()
    {
        int powerCount = 0;
        foreach (Card card in cards)
        {
            if (card.data.cardtype == CardData.CardType.Power)
            {
                powerCount++;
            }
        }
        return powerCount;
    }
}
