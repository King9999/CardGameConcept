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
    public List<CardData> cardDatabase;         //holds all cards in the game
    public CardEffect[] effectsDatabase;
    public CardAbility[] abilitiesDatabase;

    // Start is called before the first frame update
    void Start()
    {
        cardsJson = JsonUtility.FromJson<CardLibrary>(cardTextFile.text);
        effectsJson = JsonUtility.FromJson<EffectsLibrary>(effectsFile.text);

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
