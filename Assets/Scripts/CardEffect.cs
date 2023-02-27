using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//base class for all card abilities. card effects are passive abilities that trigger when the criteria is met.
public abstract class CardEffect : ScriptableObject
{
   public int effectID;
   public string effectName;
   public enum TargetType {OneCard, AllEnemyCards, AllAlliedCards, AllCards}
   public TargetType targetType;
   [TextArea]public string effectDetails;
   public virtual void Activate(CardObject user, CardObject target){}
   public virtual void Activate(CardObject user, CardObject[] targets){}
   public virtual void Activate(CardObject user, CardObject target, CardObject[] targets = null){} //used for cases where more than 1 card is targeted
   public virtual void Activate(CardObject[] allies, CardObject[] enemies){}

   public virtual bool TriggerCondition(){ return false; }  //condition for when to activate effect. Should run in update loop?
}
