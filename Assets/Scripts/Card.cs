using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int          attack;
    public int          shield;
    public int          health;
    public int          cost;
    public int          energy;
    public string       cardNameT;
    public string       DescT;

    Text cardName;
    Text Desc;

    void Start()
    {
        cardName = this.transform.Find("Name").GetComponent<Text>();
        Desc = this.transform.Find("Description").GetComponent<Text>();

        cardName.text = cardNameT;
        Desc.text = DescT;
    }
}
