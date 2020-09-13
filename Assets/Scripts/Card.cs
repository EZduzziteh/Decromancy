using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    
    public CardData data;
    public bool selected=false;
    
    public Hand hand;
    public Vector3 posInHand;
    public Quaternion rotInHand;
    // Start is called before the first frame update

    void Awake()
    {
        data.ResetCurrentHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (hand)
        {
            if (hand.player.playerID == hand.player.turnman.playerTurn)
            {
                if (selected)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
                    {
                        transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                    }
                    transform.forward = posInHand - transform.position;



                }
            }
        }
    }

    private void OnMouseEnter()
    {
        if (hand.player.ActiveHordeCard == this)
        {
            transform.Translate(0, 5, 1f);
          
        }
        else if (!selected)
        {
            
            transform.Translate(0, 3, -0.5f);
          
        }
    }
    private void OnMouseExit()
    {
        if (!selected)
        {
            ReturnToHandPos();
        }
    }

    private void OnMouseDown()
    {
        if (hand.player.playerID == hand.player.turnman.playerTurn)
        {
            if (!selected)
            {
                ToggleSelect();
            }
            else
            {
                if (transform.position.z >= hand.player.ActiveCardZValue)
                {
                    if (transform.position.x <= hand.player.ActiveCardXValue && transform.position.x >= -hand.player.ActiveCardXValue)
                    {
                        hand.SetActiveHorde(this);
                    }

                }

            }
        }
    }

    void ToggleSelect()
    {
     hand.DeselectAll();
     hand.SelectedCard = this;
     Debug.Log("selected");
     selected = true;
    // this.GetComponent<Collider>().enabled = false;
        
    }

    void ReturnToHandPos()
    {
        transform.position = posInHand;
    }
   
}
