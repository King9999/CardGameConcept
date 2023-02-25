using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public CardData data;
    public string cardName;
    public int cost;
    public string effectDetails;
    public int health;
    public int power;
    public int cardArtRef;
    public CardEffect cardEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GetCardData(CardData data)
    {
        cardName = data.cardName;
        cost = data.cost;
        effectDetails = data.effectDetails;
        health = data.health;
        power = data.power;
        cardArtRef = data.cardArt;
        cardEffect = data.cardEffect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
