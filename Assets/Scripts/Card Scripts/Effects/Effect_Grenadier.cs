using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//when an enemy takes damage, a random enemy takes half damage.
[CreateAssetMenu(menuName = "Card/Effect/Grenadier", fileName = "effect_grenadier")]
public class Effect_Grenadier : CardEffect
{
    public override void Activate(CardObject user, CardObject target, CardObject[] randTargets)
    {
        user.Attack(target);
        
        //find a random target. Can't be the same as the original target.
        if (randTargets.Length > 1)
        {
            int randNum;
            do 
            {
                randNum = Random.Range(0, randTargets.Length);
            }
            while(randTargets[randNum] == target);

            user.Attack(randTargets[randNum], user.power / 2);
        }
    }
}
