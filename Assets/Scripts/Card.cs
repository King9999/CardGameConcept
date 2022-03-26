using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public CardData data;
    public string cardName;
    public int cost;
    public string effectDetails;
    public int hitPoints;
    public int power;
    public Sprite cardArt;
    // Start is called before the first frame update
    void Start()
    {
        cardName = data.cardName;
        cost = data.cost;
        effectDetails = data.effectDetails;
        //hitPoints = data.hitPoints;
        //power = data.power;
        cardArt = data.cardArt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
