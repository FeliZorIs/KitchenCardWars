using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject          enemy;
    GameObject          eventSystem;

    bool                turnSwitch;

    enum gameState
    {
        ENEMYTURN, PLAYERTURN
    } gameState GameState;

    void Start()
    {
        GameState = gameState.PLAYERTURN;
        turnSwitch = false;

        findObjects();
        if (enemy == null)
            Debug.Log("This aint it Chief");
        else
            Debug.Log("Ladies and gentlemen... we got " + enemy.gameObject.name);

        if (eventSystem == null)
            Debug.Log("This aint it Chief");
        else
            Debug.Log("Ladies and gentlemen... we got " + eventSystem.gameObject.name);

    }

    // Update is called once per frame
    void Update()
    {
        switch (GameState)
        {
            case gameState.PLAYERTURN:
                turnSwitch = false;
                eventSystem.gameObject.SetActive(true);
                break;

            case gameState.ENEMYTURN:
                eventSystem.gameObject.SetActive(false);
                while (turnSwitch == false)
                {
                    Debug.Log("2");
                    StartCoroutine("wait");
                    turnSwitch = true;
                }
                break;
        }
    }

    // Functions

    void findObjects()
    {
        enemy = GameObject.FindGameObjectWithTag("enemy");
        eventSystem = GameObject.Find("EventSystem");
    }

    public void endTurn()
    {
        GameState = gameState.ENEMYTURN;
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(5f);
        GameState = gameState.PLAYERTURN;

        yield return null;
    }
}
