using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//base class for all card abilities.
public abstract class CardEffect : ScriptableObject
{
   public enum TargetType {OneCard, AllEnemyCards, AllAlliedCards, AllCards}
   public TargetType targetType;
   public virtual void Activate(CardObject target){}
   public virtual void Activate(CardObject[] targets){}
   public virtual void Activate(CardObject user, CardObject target){}
   public virtual void Activate(CardObject user, CardObject[] targets){}
   public virtual void Activate(CardObject[] user, CardObject[] targets){}
}
