using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void LoadNode(string scenename)
    {
        Debug.Log("Loading scene: " + scenename);
        SceneManager.LoadScene(scenename);
    }
}
