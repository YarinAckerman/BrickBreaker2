using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerText; 

    public float currentTime; 
    private bool isGameEnded = false;

    private void Update()
    {
        if (!isGameEnded)
        {
            currentTime -= Time.deltaTime; 
            int seconds = Mathf.FloorToInt(currentTime);

            if (currentTime <= 0f)
            {
                currentTime = 0f; 
                isGameEnded = true;
                HandleGameEnd(); 
            }

            string timerString = string.Format("{0:00}", seconds);
            timerText.text = timerString;
        }
    }

    private void HandleGameEnd()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


