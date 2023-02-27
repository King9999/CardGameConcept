using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//base class for abilities. Abilities are skills that cost resources to use, but are powerful. 
//if these are used, the card can do no other action for that turn.
public class CardAbility : ScriptableObject
{
    public int effectID;
    public int cost;
    [TextArea]public string abilityDetails;
    public enum TargetType {OneCard, AllEnemyCards, AllAlliedCards, AllCards}
    public TargetType targetType;
    public virtual void Activate(CardObject user, CardObject target){}
    public virtual void Activate(CardObject user, CardObject[] targets){}
    public virtual void Activate(CardObject user, CardObject target, CardObject[] targets = null){}
    public virtual void Activate(CardObject[] allies, CardObject[] enemies){}
}
