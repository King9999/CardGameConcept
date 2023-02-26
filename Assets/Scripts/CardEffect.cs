using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//base class for all card abilities.
public abstract class CardEffect : ScriptableObject
{
   public virtual void Activate(Card target){}
   public virtual void Activate(Card[] targets){}
   public virtual void Activate(Card user, Card target){}
   public virtual void Activate(Card user, Card[] targets){}
   public virtual void Activate(Card[] user, Card[] targets){}
}
