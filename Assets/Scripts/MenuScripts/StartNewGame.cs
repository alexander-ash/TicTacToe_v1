using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNewGame : MonoBehaviour
{
    string playerChoise = "X";
    string opponentChoise ;

    public void getStartSetUp (string results)
    {
        if ((results == "AI") || (results == "Friend"))
        {
            opponentChoise = results;
        }
        if ((results == "X") || (results == "O"))
        {
            playerChoise = results;
        }
    }

    // public string returnStartSetUp() { return }

    public void CheckSettingsAndStartGame ()
    {
        if (opponentChoise == "AI")
        {
            Debug.Log("Player: " + playerChoise + " Opponent: " + opponentChoise);
            SceneManager.LoadScene(3);
        }
        if (opponentChoise == "Friend")
        {
            Debug.Log("Player: " + playerChoise + " Opponent: " + opponentChoise);
            playerChoise = "X";
            SceneManager.LoadScene(3);
        }
    }



}
