using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class IsClicked : MonoBehaviour
{
    public WinChecking2Players winChecking2Players;
    static int changerPlayer;
    private void Start()
    {
        //refresh player to X at the beginning of the round
        changerPlayer = 1;
    }

    public void Push()
    {   Button btn = GetComponent<Button>();
        int btnNumber = Int32.Parse(btn.name);

        // Taking x and y from XY 
        int x = (int)btnNumber / 10;       
        int y = (int)btnNumber - (10 * x); // can use "btnNumber%10"

        winChecking2Players.setUp(x, y, changerPlayer);
        changerPlayer = -changerPlayer;
        //Debug.Log(changerPlayer);
        Destroy(btn);     
    }
}
