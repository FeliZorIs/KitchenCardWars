using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Dragable.Slot typeOfItem = Dragable.Slot.WEAPON;
    public GameObject player;
    public GameObject enemy;

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
            if (typeOfItem == d.typeOfItem && player.GetComponent<Player>().energy > eventData.pointerDrag.gameObject.GetComponent<Card>().cost)
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
        yield return new WaitForSeconds(2f);
        Destroy(thing);

        yield return null;
    }

    //Functions
    public void CardThings(GameObject card)
    {
        card.GetComponent<Card>();

    }

    public void findObject()
    {
        player = GameObject.Find("Player");
        enemy = GameObject.FindGameObjectWithTag("enemy");
    }
}
 