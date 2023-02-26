using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardGame.GenericClasses;

//card manager is responsible for setting up all cards in the game and creating and managing the deck. Card info is pulled from a JSON file.
public class CardManager : MonoBehaviour
{
    [Header("---JSON---")]
    public TextAsset cardTextFile;
    CardLibrary cardsJson;                 //contains data from cardlibrary.json

    // Start is called before the first frame update
    void Start()
    {
        cardsJson = JsonUtility.FromJson<CardLibrary>(cardTextFile.text);
        //cardsJson.cardLibrary[0].
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
