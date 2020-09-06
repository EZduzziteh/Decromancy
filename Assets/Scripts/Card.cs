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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                transform.position = new Vector3( hit.point.x,transform.position.y,hit.point.z);
            }
            transform.forward =  posInHand - transform.position ;


           
        }
    }

    private void OnMouseEnter()
    {
        if (!selected)
        {
            
            transform.Translate(0, 2, -0.5f);
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
                    Debug.Log("PlayCard");
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
