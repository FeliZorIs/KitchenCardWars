using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int                  health;
    public int                  healthMax;
    public Text                 healthCount;
    public Slider               healthSlider;

    public int                  shield;
    public Text                 shieldCount;
    public GameObject           shieldImage;

    void Start()
    {
        healthMax = 20;
        health = healthMax;

        shield = 0;

        findObjects();
    }

    private void Update()
    {
        vibeCheck();
    }

    public void findObjects()
    {
        healthCount = this.transform.Find("EnemHealth").GetComponent<Text>();
        healthSlider = this.transform.Find("Slider").GetComponent<Slider>();

        shieldImage = this.transform.Find("Shield").gameObject;
        shieldCount = shieldImage.transform.GetChild(0).GetComponent<Text>();
    }

    public void vibeCheck()
    {
        //Health check
        float healthPercent;

        if (health > healthMax)
        {
            health = healthMax;
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

        healthPercent = (float)health / (float)healthMax;
        healthSlider.value = healthPercent;

        healthCount.text = health.ToString() + "/" + healthMax.ToString();

        //Shield check
        if (shield <= 0)
        {
            shield = 0;
            shieldImage.SetActive(false);
        }
        else
        {
            shieldImage.SetActive(true);
            shieldCount.text = shield.ToString();
        }
    }
}
