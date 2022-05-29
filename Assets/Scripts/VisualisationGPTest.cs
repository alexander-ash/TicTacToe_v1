using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class VisualisationGPTest : MonoBehaviour
{
    //visualisation grid array and sprites for Items
    int[,] gridArray = new int[3, 3];
    [Header ("Sprites for Game Items")] 
    [SerializeField] Sprite empty;
    [SerializeField] Sprite plO;
    [SerializeField] Sprite plX;
    [SerializeField] Sprite whiteLine;

    int fieldWidth, fieldHeight;

    public void Start()
    {   //find the game field size     
        fieldWidth = (int)this.GetComponent<RectTransform>().rect.width;
        fieldHeight = (int)this.GetComponent<RectTransform>().rect.height;

        //creating grid based on array
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GridObjectCreation(i, j, gridArray[i, j]);
            }
        }
    }

    private void GridObjectCreation(int x, int y, int value)
    {
        GameObject gameCell = new GameObject($"X:{x}Y:{y}");
        //choose the scale for one cell
            gameCell.transform.localScale = new Vector3(fieldWidth / 3 - 50, fieldHeight / 3 - 50, 0);
        //set the cell in a "GameField" object as Child
            gameCell.transform.SetParent(GameObject.Find("GameField").transform, false);
                SpriteRenderer spriteRender = gameCell.AddComponent<SpriteRenderer>();
                spriteRender.sprite = empty;
        //set the position based on cell number
            gameCell.transform.position = new Vector3(((y - 1) * ((int)(fieldWidth / 2))), ((x - 1) * -(int)(fieldHeight / 2)), 0);
    }

    public void drawItem(int x, int y, int value)
    {
        int playerSelector = value;
        GameObject curentFeild;
        string fieldToChange = ($"X:{x}Y:{y}");
        curentFeild = GameObject.Find(fieldToChange);
        SpriteRenderer spriteRender = curentFeild.GetComponent<SpriteRenderer>();
        // 1 = Player X; -1 = Player O
        if (playerSelector == 1)
        {
            spriteRender.sprite = plX;
        }
        if (playerSelector == -1)
        {
            spriteRender.sprite = plO;
        }
    }
    public void getArrayToBuildGrid(int[,] array)
    {
        //take Main array for visualisation
        gridArray = array;
    }

    public void drawWinLine(int x, int y, int angle, int value)
    {
        
        int playerSelector = value;
        GameObject winLine = new GameObject("WinningLine");      
        //set the cell in a "GameField" object as Child
        winLine.transform.SetParent(GameObject.Find("GameField").transform, false);
        winLine.transform.Rotate(new Vector3(0, 0, angle));
        switch (angle)
        {
            case 0: // row winner
                {
                    winLine.transform.localScale = new Vector3(fieldWidth, fieldHeight, 0);
                    winLine.transform.position = new Vector3(0, ((int)(-1)*((x - 1)*(fieldWidth / 2))),0);
                    break;
                }
            case 90: // column winner
                {
                    winLine.transform.localScale = new Vector3(fieldWidth, fieldHeight, 0);
                    winLine.transform.position = new Vector3(((int)((y - 1) * (fieldWidth / 2))), 0, 0);
                    break;
                }
            case 45: // diagonal /
            case 135:// diagonal \
                {
                    winLine.transform.localScale = new Vector3(fieldWidth*1.4f, fieldHeight*1.4f, 0);                    
                    break;
                }
            

            default:
                break; break;
        }
        
        SpriteRenderer spriteRender = winLine.AddComponent<SpriteRenderer>();
        spriteRender.sprite = whiteLine;
        //make order higher to be above
        spriteRender.sortingOrder = 10; 
        // 1 = Player X; -1 = Player O
        if (playerSelector == 1)
            spriteRender.color = new Color32 (255,0,0,255);        
        if (playerSelector == -1)
           spriteRender.color = new Color32(0, 175, 255, 255);
        
    }
}
