using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//all information about a card is acquired from JSON
public abstract class CardData : ScriptableObject
{
    public string cardName;
    public int cost;
    [TextArea]public string effectDetails;
    public int power;
    public int health;
    public int cardArt;                 //reference to card sprite
    public CardEffect cardEffect;       //not sure if I need this

   public virtual void TryPlayingCard(){}            //used by AI only. Card is played if it the criteria is met.

   public virtual void Activate(Card target){}      //used to play a unique card ability if it has one
   public virtual void Activate(Card[] targets){}
   public virtual void Activate(Card user, Card target){}
   public virtual void Activate(Card user, Card[] targets){}
   public virtual void Activate(Card[] user, Card[] targets){}

}
