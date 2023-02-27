using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//game manager serves as a master singleton
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
            return;
        }

        instance = this;
        UIManager uim = GetComponentInChildren<UIManager>();
        CardManager cm = GetComponentInChildren<CardManager>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
