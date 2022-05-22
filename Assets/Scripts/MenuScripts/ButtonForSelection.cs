using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonForSelection : MonoBehaviour //, IPointerDownHandler
{
    [SerializeField] Sprite isPressed;
    [SerializeField] Sprite nonPressed;
    [SerializeField] Button pairedButton;
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
    }

    

}  
