using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardGame.Classes;

//card manager is responsible for setting up all cards in the game and creating and managing the deck. Card info is pulled from a JSON file.
public class CardManager : MonoBehaviour
{
    [Header("---JSON---")]
    public TextAsset cardTextFile;
    public TextAsset effectsFile;
    public TextAsset abilitiesFile;
    CardLibrary cardsJson;                 //contains data from cardlibrary.json
    EffectsLibrary effectsJson;
    AbilitiesLibrary abilitiesJson;
    [Header("---Database---")]
    public List<CardData> cardDatabase;         //holds all cards in the game
    public CardEffect[] effectsDatabase;
    public CardAbility[] abilitiesDatabase;

    [Header("---Card Positions---")]
    //public Transform[] cardPositions;       //card placement on board
    public Dictionary<Vector3, bool> cardPositions; //card placement on board. bool value is whether a card is in that position or not.

    [System.Serializable]
    public struct CardFace
    {
        public Texture faceTexture;
        public int artID;
    }
    public CardFace[] cardFaceTextures;

    void Awake()
    {
        cardsJson = JsonUtility.FromJson<CardLibrary>(cardTextFile.text);
        effectsJson = JsonUtility.FromJson<EffectsLibrary>(effectsFile.text);
    }

    // Start is called before the first frame update
    void Start()
    {
        cardPositions = new Dictionary<Vector3, bool>();
        for (int i = 0; i < 4; i++)
        {
            cardPositions.Add(new Vector3(-5 + (i * 2), 0, 0), false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupCardDatabase()
    {
        /*********populate effects********/
        for (int i = 0; i < effectsJson.cardEffectLibrary.Length; i++)
        {
            bool effectFound = false;
            int j = 0;
            while(!effectFound && j < effectsDatabase.Length)
            {
                if (effectsJson.cardEffectLibrary[i].effectID == effectsDatabase[j].effectID)
                {
                    effectFound = true;
                    effectsDatabase[j].effectName = effectsJson.cardEffectLibrary[i].effectName;
                    effectsDatabase[j].effectDetails = effectsJson.cardEffectLibrary[i].effectDetails;
                    effectsDatabase[j].targetType = effectsJson.cardEffectLibrary[i].targetType;
                }
                else
                {
                    j++;
                }
            }
           
        }

        /******Populate abilities*******/

        /*******Card generation*******/
        for (int i = 0; i < cardsJson.cardLibrary.Length; i++)
        {
            CardData card = ScriptableObject.CreateInstance<CardData>();
            card.name = "card_" + cardsJson.cardLibrary[i].cardName.Trim(' ').ToLower();  //name of scriptable object
            card.cardID = cardsJson.cardLibrary[i].cardID;
            card.cardName = cardsJson.cardLibrary[i].cardName;
            card.cost = cardsJson.cardLibrary[i].cost;
            card.cardArt = cardsJson.cardLibrary[i].artID;
            card.effectID = cardsJson.cardLibrary[i].effectID;
            card.abilityID = cardsJson.cardLibrary[i].abilityID;
            card.power = cardsJson.cardLibrary[i].power;
            card.health = cardsJson.cardLibrary[i].health;

            //TODO: add card ability and effect by matching IDs
            if (cardsJson.cardLibrary[i].effectID >= 0)
            {
                //find effect and add effect to card
                bool effectFound = false;
                int j = 0;
                while(!effectFound && j < effectsDatabase.Length)
                {
                    if (cardsJson.cardLibrary[i].effectID == effectsDatabase[j].effectID)
                    {
                        effectFound = true;
                        card.cardEffect = effectsDatabase[j];
                    }
                    else
                    {
                        j++;
                    }
                }
            }

            cardDatabase.Add(card);
        }
    }
}
