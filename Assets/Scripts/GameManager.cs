using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject          enemy;
    GameObject          player;
    GameObject          eventSystem;
    Transform           hand;
    public GameObject[] Cards = new GameObject[10];

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
                    StartCoroutine("enemyAction");
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
        player = GameObject.Find("Player");
        eventSystem = GameObject.Find("EventSystem");
        hand = GameObject.Find("Hand").transform;

/*        if (enemy == null)
            Debug.Log("This aint it Chief");
        else
            Debug.Log("Ladies and gentlemen... we got " + enemy.gameObject.name);

        if (player == null)
            Debug.Log("This aint it Chief");
        else
            Debug.Log("Ladies and gentlemen... we got " + player.gameObject.name);

        if (eventSystem == null)
            Debug.Log("This aint it Chief");
        else
            Debug.Log("Ladies and gentlemen... we got " + eventSystem.gameObject.name);

        if (hand == null)
            Debug.Log("This aint it Chief");
        else
            Debug.Log("Ladies and gentlemen... we got " + hand.gameObject.name); */
    }

    public void endTurn()
    {
        emptyHand();
        GameState = gameState.ENEMYTURN;
    }

    public void emptyHand()
    {
        int kidCount = hand.childCount;
       // Debug.Log(kidCount);

        for (int i = 0; i < kidCount; i++)
        {
            Destroy(hand.GetChild(i).gameObject);
            kidCount = hand.childCount;
        }
    }

    public void newHand()
    {
        int drawSize = maxHandSize;

        for (int i = 1; i <= drawSize; i++)
        {
            Instantiate(Cards[Random.RandomRange(0, Cards.Length-1)], hand);
        }
    }
    
    IEnumerator enemyAction()
    {
        yield return new WaitForSeconds(1.5f);
        int choice = Random.Range(1, 3);
        if (choice == 1)
        {
            player.GetComponent<Player>().health -= Random.Range(5, 10);
        }

        if (choice == 2)
        {
            enemy.GetComponent<Enemy>().shield += Random.Range(1, 5);
        }

        if (choice == 3)
        {
            
        }

        yield return new WaitForSeconds(1.5f);
        player.GetComponent<Player>().energy = player.GetComponent<Player>().energyMax;
        GameState = gameState.PLAYERTURN;

        yield return null;
    }
}
