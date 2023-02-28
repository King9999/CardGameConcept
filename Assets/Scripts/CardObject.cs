using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class CardObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //public CardData data;
    public string cardName;
    public int cost;
    public string effectDetails;
    public string abilityDetails;
    public int health;
    public int power;
    public int cardArtRef;
    public CardEffect cardEffect;
    public CardAbility ability;
    [Header("---Text Meshes---")]
    public TextMeshPro cardNameText;
    public TextMeshPro costText;
    public TextMeshPro healthText;
    public TextMeshPro powerText;
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager gm = GameManager.instance;
        MeshRenderer r = gameObject.GetComponent<MeshRenderer>();
        Debug.Log(r.material.GetTexture("_MainTex2").name);     //gives me name of the card face filename
        r.material.SetTexture("_MainTex2", gm.cm.cardFaceTextures[1].faceTexture);
        Debug.Log(r.material.GetTexture("_MainTex2").name);
        Resources.UnloadUnusedAssets();     //must call this when dealing with assets in resources folder.
    }

    public void GetCardData(CardData data)
    {
        cardName = data.cardName;
        cost = data.cost;
        effectDetails = data.cardEffect.effectDetails;
        health = data.health;
        power = data.power;
        cardArtRef = data.cardArt;
        cardEffect = data.cardEffect;
        ability = data.ability;
        abilityDetails = data.ability.abilityDetails;
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

    //shows card details window
    public void OnPointerEnter(PointerEventData data)
    {
        ShowCardDetails(ability.abilityDetails, cardEffect.effectDetails);
    }

    public void OnPointerExit(PointerEventData data)
    {
        GameManager gm = GameManager.instance;
        gm.uim.ToggleCardWindow(false);
    }

    void ShowCardDetails(string ability, string effects)
    {
        GameManager gm = GameManager.instance;
        gm.uim.abilityText.text = ability;
        gm.uim.effectText.text = effects;
        gm.uim.ToggleCardWindow(true);
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
