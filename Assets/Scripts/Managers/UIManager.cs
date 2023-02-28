using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("---Card Details Window---")]
    public GameObject cardWindowContainer;
    public TextMeshProUGUI effectText;
    public TextMeshProUGUI abilityText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region UI Toggles

    public void ToggleCardWindow(bool toggle)
    {
        cardWindowContainer.gameObject.SetActive(toggle);
    }

    #endregion
}
