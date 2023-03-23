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

        //test cards
        for (int i = 0; i < cm.cardDatabase.Count; i++)
        {
            CardObject card = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            card.GetCardData(cm.cardDatabase[i]);

            //look for available positions
            int j = 0;
            List<Vector3> pos = new List<Vector3>(cm.cardPositions.Keys);
            bool posFound = false;
            while(!posFound && j < pos.Count)
            {
                Debug.Log(pos[j]);
                if (cm.cardPositions[pos[j]] == false)
                {
                    card.transform.position = pos[j];
                    cm.cardPositions[pos[j]] = true;
                    posFound = true;
                }
                j++;
            }
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
