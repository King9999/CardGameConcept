using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CardGame.Classes
{
    /*** Card Classes for JSON ***/
    [Serializable]
    public class Card
    {
        public int cardID;
        public int artID;
        public int cost;
        public int power;
        public int health;
        public int effectID;
        public int abilityID;
        public string cardName;
        public string effectDetails;
    }

    [Serializable]
    public class CardLibrary
    {
        public Card[] cardLibrary;
    }
}
