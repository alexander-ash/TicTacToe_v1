using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    private bool startedLoad = false;
    public void ChangeTheSceneTo (int sceneToChange)
    {
        Application.LoadLevel(sceneToChange); 
    }
    public void QuitGame ()
    {
        Application.Quit();
        Debug.Log ("ByeBye");
    }
    
    
}

