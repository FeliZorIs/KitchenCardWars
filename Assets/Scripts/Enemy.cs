using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int  health;
    public int  shield;

    public void vibeCheck()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        
    }

    private void Update()
    {
        vibeCheck();
    }
}
