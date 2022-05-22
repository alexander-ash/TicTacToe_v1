using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinChecking2Players : MonoBehaviour

{
    [Header ("Script for Visualizayion")]
    public VisualisationGPTest visualisation;
    public static int[,] gameArrayMain = new int[3, 3];
    [Header("Text & Counters")]
    [SerializeField] GameObject winCounterRed;
    [SerializeField] GameObject winCounterBlue;
    [SerializeField] GameObject winResultsText;
    public static int counterX = 0, counterO = 0;
    string resultLine = "";
    int winLineAngle;
    int unfilledField=9;
    bool roundOver = false;

    public void Start()
    {
        //Creating main Array [3,3] as field grid cell with value of player (currently 0 = null)

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                gameArrayMain[i, j] = 0;
            }
        }
        //Sending array for visualisation
        visualisation.getArrayToBuildGrid(gameArrayMain);
    }
    private void Update()
    {

        TextMeshProUGUI xx = winCounterRed.GetComponent<TextMeshProUGUI>();
        xx.text = ($"{counterX}");
        TextMeshProUGUI oo = winCounterBlue.GetComponent<TextMeshProUGUI>();
        oo.text = ($"{counterO}");
        TextMeshProUGUI res = winResultsText.GetComponent<TextMeshProUGUI>();
        res.text = (resultLine);
       
        // restart level when round is over
        if ((Input.GetMouseButtonDown(0)) && (roundOver))
        {
            
            Application.LoadLevel(3);
        }
    }

    //Take the data from clicking on field and sending to visualisation
    public void setUp(int x, int y, int value)
    {
        gameArrayMain[x, y] = value;
        visualisation.drawItem(x, y, gameArrayMain[x, y]);
        unfilledField--;

        if (OnesWin(x, y))
        {
            if (gameArrayMain[x, y] == 1)
            {
                counterX++;
                resultLine = ("WINNER:X");
            }
            if (gameArrayMain[x, y] == -1)
            {
                counterO++;
                resultLine = ("WINNER:O");
            }
            visualisation.drawWinLine(x, y, winLineAngle, value);
            roundOver = true;
        }
        else if (unfilledField == 0) 
        {
            resultLine = ("DRAW");
            roundOver = true;
        }
    }

    bool OnesWin(int x, int y)
    {
        bool allSame = false;

        // checking rows
        if (gameArrayMain[x, 0] == gameArrayMain[x, 1] && gameArrayMain[x, 0] == gameArrayMain[x, 2])
        {
            allSame = true;
            winLineAngle = 0;
        }
        // checking collumns
        else if (gameArrayMain[0, y] == gameArrayMain[1, y] && gameArrayMain[0, y] == gameArrayMain[2, y])
        {
            allSame = true;
            winLineAngle = 90;
        }
        // checking diagonal \
        else if ((x == y))
        {
            if (gameArrayMain[1, 1] == gameArrayMain[0, 0] && gameArrayMain[0, 0] == gameArrayMain[2, 2])
            {
                allSame = true;
                winLineAngle = 135;
            }
        }
        // checking diagonal /
        else if ((x + y) == 2)
        {
            if (gameArrayMain[1, 1] == gameArrayMain[2, 0] && gameArrayMain[2, 0] == gameArrayMain[0, 2])
            {
                allSame = true;
                winLineAngle = 45;
            }
        }
        // if no win situation -> return "false"
        return allSame;
    }

    // refresh Win counter
    public void RefreshStaticValues()
    {
        counterX = 0;
        counterO = 0;
    }

    //public void CheckForWinner(int [,] array)
    //{

    //    //ArrayChecker(array);
    //    //just for test purposes
    //    //if (((array[0, 0] == array[1, 1]) && (array[0, 0] == array[2, 2]) &&( array[1, 1] != 0)) ||
    //    //   ((array[2, 0] == array[1, 1]) && (array[1, 1] == array[0, 2])) && (array[1, 1] != 0))
    //    //if (onesWin)
    //    if (winSituation)
    //    {
   
    //        if (array[r, c] == 1)
    //        {
    //            counterX++; 
    //            resultLine = ("WINNER:X");
    //        }
    //        else
    //        {
    //            counterO++;
    //            resultLine = ("WINNER:O");
    //        }
    //        roundOver = true; 
    //    }
    //    if (drawRoundCounter==0)
    //    {
    //        resultLine = ("DRAW");
    //        roundOver = true;
    //    }
    //}
    //public void ArrayChecker(int[,] array)
    //{
    //    r = 0;
    //    c = 0;
    //    // checking ROWs
    //    for (int i = 0; i < 3; i++)
    //    {
    //        // stay positive =)))
    //        bool allSame = true;
    //        // checking inside a row

    //        for (int j = 1; j < 3; j++)
    //        {
    //            // if element is not equal to previous in a row or = 0, just go further
    //            if (array[i, j] != array[i, j - 1] || array[i, j] == 0)
    //            {
    //                allSame = false;
    //                break;
    //            }
    //        }
    //        if (allSame)
    //        {
    //            winSituation = true;
    //            r = i;
    //            break;
    //        }
    //        Debug.Log("RR");
    //    }
    //    if (!winSituation)
    //    {
    //        //check COLUMNs
    //        for (int j = 0; j < 3; j++)
    //        {
    //            bool allSame = true;
    //            for (int i = 1; i < 3; i++)
    //            {
    //                if (array[i, j] != array[i - 1, j] || array[i, j] == 0)
    //                {
    //                    allSame = false;
    //                    break;
    //                }
    //            }
    //            if (allSame)
    //            {
    //                winSituation = true;
    //                c = j;
    //                break;
    //            }
    //            Debug.Log("CC");
    //        }
    //    }
    //    if (!winSituation)
    //    {
    //        //check Diagonal 1

    //        int i = 1   ;
    //            bool allSame = true;
    //            if (array[i, i] != array[i - 1, i - 1] || array[i, i] != array[i + 1, i + 1] || array[i, i] == 0)
    //            {
    //                allSame = false;                   
    //            }
    //            if (allSame)
    //            {
    //                winSituation = true;
    //                r = c = i;                   
    //            }
                    
    //    }
    //    if (!winSituation)
    //    {
    //        //check Diagonal 2
    //       bool allSame = true;
    //       if ((array[1, 1] != array[2, 0] || array[1, 1] != array[0, 2]) || array[1, 1] == 0)
    //       {
    //           allSame = false;
    //       }
               
    //       if (allSame)
    //       {
    //          winSituation = true;
    //          r = c = 1;
                   
    //       }
           
    //    }

    //    Debug.Log("STOP ON " + (r+1) + "th row " + (c+1) + "th col");
    //}




}

    

