using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    public List<Card> cards=new List<Card>();

    AudioSource aud;
    //Audio Clips

    [SerializeField]
    AudioClip Draw_01;
    [SerializeField]
    AudioClip Draw_02;
    [SerializeField]
    AudioClip Draw_03;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
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

            aud.clip = GetRandomDrawSound();
            aud.Play();
            
            cards.RemoveAt(0);
          
            return Temp;
        }
        else
        {
            Debug.LogWarning("no cards in deck");
            return null;

            //#TODO Reshuffle discard pile into deck
        }
    }

    AudioClip GetRandomDrawSound()
    {
        int randomnum = Random.Range(0, 3);


        switch (randomnum)
        {
            case 0:
                return Draw_01;
            case 1:
                return Draw_02;
            case 2:
                return Draw_03;
            default:
                return Draw_01;



        }

        
    }

  
}
