using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Dragable.Slot typeOfItem = Dragable.Slot.WEAPON;

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
        GameObject enemy = null;
        enemy = GameObject.FindGameObjectWithTag("enemy");

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
        Debug.Log(eventData.pointerDrag.name + " was dropped on to " + gameObject.name);

        Dragable d = eventData.pointerDrag.GetComponent<Dragable>();
        if (d != null)
        {
            if (typeOfItem == d.typeOfItem)
            {
                d.parentToReturnTo = this.transform;

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

}
 