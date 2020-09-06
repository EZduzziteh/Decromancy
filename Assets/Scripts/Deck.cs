using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    public List<Card> cards=new List<Card>();

    private void Awake()
    {
        foreach (Card card in GetComponentsInChildren<Card>())
        {
            cards.Add(card);
        }
        Shuffle();
    }
    // Start is called before the first frame update
    void Start()
    {
    
      
    }

   
    void Update()
    {
       
    }

    public void Shuffle()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            Card temp = cards[i];
            int randomIndex = Random.Range(i, cards.Count);
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
    }

    public Card Draw()
    {
        if (cards.Count > 0)
        {
            Card Temp = cards[0];

            cards.RemoveAt(0);
            return Temp;
        }
        else
        {
            Debug.LogWarning("no cards in deck");
            return null;
        }
    }
}
