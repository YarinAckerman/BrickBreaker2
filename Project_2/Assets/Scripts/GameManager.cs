using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    public int lives;
    public int score;
    public Text livesText;
    public Text scoreText;
    public bool gameOver;
    public GameObject panel;
    public int numOfBricks;
    public int powerUpBrick;
    public Transform[] levels;
    public int currentLevelIndex = 0; 
    public GameObject ball;
    public GameObject Player;

    // Start is called before the first frame update
    void Awake()
    {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        numOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        powerUpBrick = Random.Range(1, numOfBricks-3);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void AddLives(int num)
    { 
        lives += num;

        if (lives < 0)
        {
            lives = 0;
            GameOver();
        }

        livesText.text = "Lives: " + lives;
    }
    public void AddScore(int num)
    {
        score += num;
        scoreText.text = "Score: " + score;
    }

    public void GameOver() {

        gameOver = true;
        panel.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quitted");
    }

    public void UpdateNumOfBricks() {

        numOfBricks--;
        if(numOfBricks <= 0)
        {
            if (currentLevelIndex >= levels.Length - 1)
            {
                GameOver();
            }
            else
            {
                gameOver = true;

                Invoke("LoadLevel", 3f);

            }
        }
    }

    public void LoadLevel()
    {
        currentLevelIndex++;
        ResetBallPosition();
        Instantiate(levels[currentLevelIndex],Vector2.zero,Quaternion.identity);
        numOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        gameOver = false;
        

    }

    public void ResetBallPosition()
    {
        ball.transform.position = Player.transform.position;

        Rigidbody2D ballRigidbody = ball.GetComponent<Rigidbody2D>();
        ballRigidbody.velocity = Vector2.zero;
        ballRigidbody.angularVelocity = 0f;

        BallInitializer ballInitializer = ball.GetComponent<BallInitializer>();
        ballInitializer.inPlay = false;
    }
}
