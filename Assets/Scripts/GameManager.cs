using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("The Game Manager is NULL");
            
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }
    #endregion

    private int scoreMultiplier = 6;
    private float count = 0;
    private float startSpeed = 8;
    private float acceleration = 2;
    private float startScroll = 0.2f;
    private float scrollAcc = 0.01f;
    private AudioSource audioSource;

    public Text scoreText;
    public Text highScoreText;
    public Text highScore;
    public GameObject gameOverObj;
    public GameObject nightSky;
    public GameObject sky;
    public Material materialDay;
    public Material materialNight;
    public float score = 0f;
    public float gameSpeed;
    public float scrollSpeed;
    public bool gameOver = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        gameOverObj.SetActive(false);
    }

    void Update()
    {
        UpdateScore();
        ManageSpeed();
        ActivateNightMode();
    }

    private void UpdateScore()
    {
        if (!gameOver)
        {
            score += Time.deltaTime * scoreMultiplier;
            scoreText.text = "Score: " + (int)score;
        }

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", (int)score);
            highScore.text = "" + (int)score;
        }
    }

    private void ManageSpeed()
    {
        count = Mathf.Ceil(score) / 100;
        gameSpeed = startSpeed + (count * acceleration);
        scrollSpeed = startScroll + (count + scrollAcc) / 20;

        if (gameOver)
            gameSpeed = 0;
    }

    private void ActivateNightMode()
    {
        if ((int)score / 400 % 2 == 0)
        {
            sky.GetComponent<Renderer>().material = materialDay;
            scoreText.color = Color.black;
            highScoreText.color = Color.black;
            highScore.color = Color.black;
            nightSky.SetActive(false);
        }
        else
        {
            sky.GetComponent<Renderer>().material = materialNight;
            scoreText.color = Color.white;
            highScoreText.color = Color.white;
            highScore.color = Color.white;
            nightSky.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
        audioSource.Play();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        audioSource.Play();
    }
}
