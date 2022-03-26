using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class CardData : ScriptableObject
{
    public string cardName;
    public int cost;
    [TextArea]public string effectDetails;
    public Sprite cardArt;
    public CardEffect cardEffect;
}
