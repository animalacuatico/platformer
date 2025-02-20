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
        switch(variableToUpdate) // Mediante un switch, establezco las siguientes variables para que se actualicen constantemente.
        {
            case InterfaceVariable.COINS_GAME:
                textComponent.text = "Monedas actuales: " + GameManager.instance.GetCoins();
                break;
            case InterfaceVariable.TIME:
                textComponent.text = "Tiempo actual: " + GameManager.instance.GetTime().ToString("00.00" + " s");
                break;
        }
    }
}
