using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardObject : MonoBehaviour
{
    public CardData data;
    public string cardName;
    public int cost;
    public string effectDetails;
    public int health;
    public int power;
    public int cardArtRef;
    public CardEffect cardEffect;
    public CardAbility ability;
    
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
        ability = data.ability;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //attack another card
    public void Attack(CardObject target)
    {
        target.health -= power;
        if (target.health <= 0)
            target.DestroyCard();
        
        //check for an effect to trigger
        if (cardEffect != null)
        {
            TriggerEffect(cardEffect);
        }
    }

    //used in special cases where I need to specify the damage
    public void Attack(CardObject target, int damage)
    {
        target.health -= damage;
        if (target.health <= 0)
            target.DestroyCard();

        //check for an effect to trigger
        if (cardEffect != null)
        {
            TriggerEffect(cardEffect);
        }
    }

    public void DestroyCard()
    {
        gameObject.SetActive(false);
    }

    public void TriggerEffect(CardEffect effect, CardObject user = null, CardObject target = null, CardObject[] targets = null)
    {
        switch(effect.targetType)
        {
            case CardEffect.TargetType.OneCard:
                effect.Activate(user, target, targets);
                break;

            case CardEffect.TargetType.AllEnemyCards:
                effect.Activate(user, targets);
                break;
        }
    }
}
