using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject          enemy;
    GameObject          eventSystem;
    Transform           hand;
    public GameObject   Card;

    bool                turnSwitch;
    bool                turnSwitch2;
    bool                drawCards;

    int          maxHandSize = 7;

    enum gameState
    {
        ENEMYTURN, PLAYERTURN
    } gameState GameState;

    void Start()
    {
        GameState = gameState.PLAYERTURN;
        turnSwitch = false;
        drawCards = false;

        findObjects();    
    }

 //=======================================
 //             Game Happenings
 //=======================================
    void Update()
    {
        switch (GameState)
        {
            case gameState.PLAYERTURN:
                turnSwitch = false;
                while (turnSwitch2 == false)                //Debug for checking turns
                {
                    Debug.Log("Player Turn");
                    turnSwitch2 = true;
                }

                while (drawCards == false)
                {
                    newHand();
                    drawCards = true;
                }

                eventSystem.gameObject.SetActive(true);
                break;

            case gameState.ENEMYTURN:
                eventSystem.gameObject.SetActive(false);
                turnSwitch2 = false;
                drawCards = false;

                while (turnSwitch == false)
                {
                    Debug.Log("Enemy Turn");
                    StartCoroutine("wait");
                    turnSwitch = true;
                }
                break;
        }
    }

//========================================
//              Functions
//========================================

    void findObjects()
    {
        enemy = GameObject.FindGameObjectWithTag("enemy");
        eventSystem = GameObject.Find("EventSystem");
        hand = GameObject.Find("Hand").transform;

        if (enemy == null)
            Debug.Log("This aint it Chief");
        else
            Debug.Log("Ladies and gentlemen... we got " + enemy.gameObject.name);

        if (eventSystem == null)
            Debug.Log("This aint it Chief");
        else
            Debug.Log("Ladies and gentlemen... we got " + eventSystem.gameObject.name);

        if (hand == null)
            Debug.Log("This aint it Chief");
        else
            Debug.Log("Ladies and gentlemen... we got " + hand.gameObject.name);
    }

    public void endTurn()
    {
        emptyHand();
        GameState = gameState.ENEMYTURN;
    }

    public void emptyHand()
    {
        int kidCount = hand.childCount;
        Debug.Log(kidCount);

        for (int i = 0; i < kidCount; i++)
        {
            Destroy(hand.GetChild(i).gameObject);
            kidCount = hand.childCount;
        }

        Debug.Log(kidCount);
    }

    public void newHand()
    {
        int drawSize = maxHandSize;

        for (int i = 1; i <= drawSize; i++)
        {
            Instantiate(Card, hand);
        }
    }
    
    IEnumerator wait()
    {
        yield return new WaitForSeconds(3f);
        GameState = gameState.PLAYERTURN;

        yield return null;
    }
}
