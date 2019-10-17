using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeAnimation : MonoBehaviour
{
    public Animator anitor;
    bool setPlay = false;

    public void SetThatBoolTrue()
    {
        setPlay = true;
    }

    public void SetThatBoolFalse()
    {
        setPlay = false;
    }

    public void DoIT()
    {
        if (setPlay)
        {
            anitor.SetBool("play", true);
        }
        else
        {
            anitor.SetBool("play", false);
        }
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        anitor.SetBool("play", true);
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        anitor.SetBool("play", false);
        Debug.Log("Mouse is no longer on GameObject.");
    }
}
