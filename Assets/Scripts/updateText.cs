using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class updateText : MonoBehaviour
{
    public InterfaceVariable variableToUpdate;
    private TMP_Text textComponent;
    private void Start()
    {
        textComponent = GetComponent<TMP_Text>();
    }
    void Update()
    {
        switch(variableToUpdate)
        {
            case InterfaceVariable.COINS_GAME:
                textComponent.text = "Monedas actuales: " + GameManager.instance.GetCoins();
                break;
            case InterfaceVariable.TIME:
                textComponent.text = "Tiempo actual: " + GameManager.instance.GetTime();
                break;
        }
    }
}
