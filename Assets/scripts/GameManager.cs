using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public string highscoreKey;

    [Header("Player-specific components")]
    public Rigidbody2D playerRigidbody;
    public GameObject player;

    [Header("Game-Over Popup")]
    public Canvas gameOverUi;
    public Text totalScore, hiScore;

    [Header("Game HUD")]
    public Canvas gameHud;
    public Text scoreDisplay, instructionText;

    private int scoreValue, bestValue;
    private const string labelCurrentScore = "Score: ";
    private const string labelHiScore = "Hi Score: ";
    private const string labelYourScore = "Your Score: ";


    private void Start()
    {
        gameOverUi.gameObject.SetActive(false);
        gameHud.gameObject.SetActive(true);
        instructionText.gameObject.SetActive(true);
        playerRigidbody.bodyType = RigidbodyType2D.Static;
        Time.timeScale = 1;
    }

    private void FixedUpdate()
    {
        StartGame();
        ScoreDisplay();
    }

    void StartGame()
    {
        if (Input.GetMouseButtonDown(0) || Input.anyKey)
        {
            playerRigidbody.bodyType = RigidbodyType2D.Dynamic;
            instructionText.gameObject.SetActive(false);
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverUi.gameObject.SetActive(true);
        gameHud.gameObject.SetActive(false);
        HiScore();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverUi.gameObject.SetActive(false);
    }

    public void ScoreDisplay()
    {
        scoreValue = (int)player.transform.position.x / 10;
        scoreDisplay.text = labelCurrentScore + scoreValue;
    }

    public void HiScore()
    {
        int highscore = PlayerPrefs.GetInt(highscoreKey);
        if (scoreValue > highscore)
        {
            highscore = scoreValue;
            PlayerPrefs.SetInt(highscoreKey, highscore);
            totalScore.text = labelYourScore + scoreValue;
            hiScore.text = labelHiScore + highscore;
        }
        else
        {
            totalScore.text = labelYourScore + scoreValue;
            hiScore.text = labelHiScore + highscore;
        }
    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
                Time.timeScale = 0;
            else Time.timeScale = 1;

        }
    }
}
