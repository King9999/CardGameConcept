using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//game manager serves as a master singleton
public class GameManager : MonoBehaviour
{
    public CardObject cardPrefab;

    //singletons
    public static GameManager instance;
    public UIManager uim {get; private set;}
    public CardManager cm {get; private set;}

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
            return;
        }

        instance = this;
        uim = GetComponentInChildren<UIManager>();
        cm = GetComponentInChildren<CardManager>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        //UI setup
        uim.ToggleCardWindow(false);

        //card setup
        cm.SetupCardDatabase();

        //test card
        CardObject card = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
