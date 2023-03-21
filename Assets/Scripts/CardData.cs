using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//all information about a card is acquired from JSON
[CreateAssetMenu(menuName = "Card/Unit", fileName = "card_")]
public class CardData : ScriptableObject
{
    public int cardID;
    public string cardName;
    public int cost;
    public int power;
    public int health;
    public int cardArt;                 //reference to card sprite
    public int effectID = -1;
    public int abilityID = -1;
    public CardEffect cardEffect;       //can be null
    public CardAbility ability;         //can be null

    //THE CODE BELOW COULD BE USED FOR A FUTURE GAME. I WANT TO MAKE A BASIC GAME FOR NOW

    /* Card Types
    --------------
    Unit: cards with power and health
    Structure: card with health. Can't attack
    Defensive: base defense. Can only attack when attacked, and they deal damage first.
    Command: basically spell cards in other games. One time use. */
    /*public enum CardType {Unit, Structure, Defensive, Command}
    public CardType cardType;

    //applies to units and defensive cards only
    public enum WeaponType {Bullet, Rocket, Cannon, Flame, Laser}
    public WeaponType weapon;

    [Header("---Movement---")]  //cards can have more than 1 movement type
    public bool movementGround;
    public bool movementAir;
    public bool movementStealth;  */

   public virtual void TryPlayingCard(){}            //used by AI only. Card is played if it the criteria is met.
}
