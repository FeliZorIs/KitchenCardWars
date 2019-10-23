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

    public string       cardNameString;
    public string       DescString;

    Text CostT;
    Text cardName;
    Text Desc;

    void Start()
    {
        cardName = this.transform.Find("Name").GetComponent<Text>();
        Desc = this.transform.Find("Description").GetComponent<Text>();
        CostT = this.transform.Find("CostDisplay").GetComponentInChildren<Text>();

        if (cardNameString == null || Desc == null)
        {
            Debug.Log("One of the values is null");
        }
        else
        {
            cardName.text = cardNameString;
            Desc.text = DescString;
            CostT.text = cost.ToString();
        }
    }
}
