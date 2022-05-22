using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonForSelectionAndDisable : MonoBehaviour 
{
    [Header ("Sprites")]
    [SerializeField] Sprite isPressed;
    [SerializeField] Sprite nonPressed;
    [Header("Dependencies")]
    [SerializeField] Button pairedButton;
    [SerializeField] Button disabledButtonA;
    [SerializeField] Button disabledButtonB;

    public StartNewGame startNewGame;
    public string urChoise;
    public void ClickOnButton()
    {   
        Button btn = this.gameObject.GetComponent<Button>();
        Image btnImage = btn.GetComponent<Image>();
        btnImage.sprite = isPressed;
        (pairedButton.GetComponent<Image>()).sprite = nonPressed;
        urChoise = btn.name;
        startNewGame.getStartSetUp(urChoise);
        Debug.Log(urChoise);
        if ((this.gameObject.name == "Friend"))
        {            
            ButtonDisable(disabledButtonA);
            ButtonDisable(disabledButtonB);
        }
        else
        {
            ButtomEnable(disabledButtonA);
            ButtomEnable(disabledButtonB);            
        }
    }

    void ButtonDisable(Button gameObject)
    {
        Image disa = gameObject.GetComponent<Image>();
        disa.sprite = nonPressed;
        disa.color = new Color32(255, 255, 255, 100);
        gameObject.interactable = false;
    }

    void ButtomEnable(Button gameObject)
    {
        gameObject.interactable = true;
        Image disa = gameObject.GetComponent<Image>();        
        disa.color = new Color32(255, 255, 255, 255);
    }

}
