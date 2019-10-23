using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Dragable.Slot        typeOfItem = Dragable.Slot.WEAPON;
    public GameObject player;
    public GameObject enemy;

    /*public int enemHealth;
    public int enemyShield;

    public int playerHealth;
    public int playerShield;
    public int playerEnergy; */

    void Start()
    {
        findObject();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }

        Dragable d = eventData.pointerDrag.GetComponent<Dragable>();
        if (d != null)
        {
            if (typeOfItem == d.typeOfItem)
            {
                d.placeholderParent = this.transform;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }

        Dragable d = eventData.pointerDrag.GetComponent<Dragable>();
        if (d != null && d.placeholderParent == this.transform)
        {
            if (typeOfItem == d.typeOfItem)
            {
                d.placeholderParent = d.parentToReturnTo;
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {        
        //Debug.Log(eventData.pointerDrag.name + " was dropped on to " + gameObject.name);

        Dragable d = eventData.pointerDrag.GetComponent<Dragable>();
        if (d != null)
        {
            if (typeOfItem == d.typeOfItem && player.GetComponent<Player>().energy >= eventData.pointerDrag.gameObject.GetComponent<Card>().cost)
            {
                d.parentToReturnTo = this.transform;

                CardThings(eventData.pointerDrag.gameObject);
                
                GameObject[] parms = new GameObject[1] { eventData.pointerDrag.gameObject };
                StartCoroutine("Wait", parms);
            }
        }
    }

    //Coroutines
    IEnumerator Wait(GameObject[] parms)
    {
        GameObject thing = parms[0];
        yield return new WaitForSeconds(1f);
        Destroy(thing);

        yield return null;
    }

    //Functions
    public void CardThings(GameObject card)
    {
        /* 
         * playerHealth
         * playerShield
         * playerEnergy
         * 
         * enemyHealth
         */

        player.GetComponent<Player>().health += card.GetComponent<Card>().health;           //playerHealth
        player.GetComponent<Player>().shield += card.GetComponent<Card>().shield;           //playerShield
        player.GetComponent<Player>().energy -= card.GetComponent<Card>().cost;             //playerEnergy

        enemy.GetComponent<Enemy>().health -= card.GetComponent<Card>().attack;
    }

    public void findObject()
    {
        player = GameObject.Find("Player");
        enemy = GameObject.FindGameObjectWithTag("enemy");
    }
}
 