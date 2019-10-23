using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int              health;
    public int              healthMax;
    public Text             healthCount;
    public Slider           healthSlider;

    public int              energy;
    public int              energyMax;
    public Text             energyCount;

    public int              shield;
    public GameObject       shieldImage;
    public Text             shieldCount;

    void Start()
    {
        healthMax = 80;
        health = healthMax;

        energyMax = 6;
        energy = energyMax;

        shield = 0;

        findObjects();
    }

    void Update()
    {
        vibeCheck();
    }

    public void findObjects()
    {
        healthCount = this.transform.Find("HealthNum").GetComponent<Text>();
        healthSlider = this.transform.Find("Slider").GetComponent<Slider>();

        energyCount = this.transform.Find("Energy").transform.GetChild(0).GetComponent<Text>();

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
            Debug.Log("Game Over, its GG");
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

        //Energy check
        if (energy <= 0)            //min
        {
            energy = 0;
        }

        if (energy >= energyMax)    //max
        {
            energy = energyMax;
        }

        energyCount.text = energy.ToString() + "/" + energyMax.ToString();
    }
}
