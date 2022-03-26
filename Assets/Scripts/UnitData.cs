using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//these are the creatures or minions of the game. 
[CreateAssetMenu(menuName = "Card/Unit", fileName = "unit_")]
public class UnitData : CardData
{
    public int hitPoints;
    public int power;
}
