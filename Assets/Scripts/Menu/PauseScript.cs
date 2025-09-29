using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseScript : MonoBehaviour
{
    bool isPaused = false;
    public GameObject menuPause;
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) 
            {
                isPaused = false;
                menuPause.SetActive(isPaused);
                Time.timeScale = 1f;

            }
            else
            {
                isPaused = true;
                menuPause.SetActive(isPaused);
                Time.timeScale = 0f;
            }
        }
    }
}
