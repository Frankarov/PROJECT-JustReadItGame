using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject canvasReading;
    public GameObject canvasQuiz;
    public GameObject canvasShop;
    public GameObject insufficient;
    public GameObject canvasGameOver;

    public TMP_Text textReading;
    public Text timerText;
    public TMP_Text scoreText;
    public string[] reading;
    private int readingVersion;
    
    public float countdownDuration;
    public float currentTime;
    private int currentTimeInt;
    public bool finish = false;

    public GameObject textGame;
    public BoldScript boldScript;
    [SerializeField]
    private int thenScore;
    private bool kunci = false;

    void Start()
    {
        textReading.text = reading[readingVersion];
        currentTime = countdownDuration;
        readingVersion = 0;
    }

    void Update()
    {

        UpdateTextScore();

        if(currentTime > 0 && finish == false)
        {
            currentTime -= Time.deltaTime;
            UpdateTextTimer();

        }
        else if(currentTime <=0)
        {
            currentTime = 0;
        }
    }

    private void UpdateTextTimer()
    {
        int seconds = Mathf.CeilToInt(currentTime);
        timerText.text = seconds.ToString();

    }

    private void UpdateTextScore()
    {
        int previousScore = PlayerPrefs.GetInt("Score");
        scoreText.text = "Score : " + previousScore;

        if(previousScore < 0 && !kunci)
        {
            Debug.Log("GameOver");
            canvasGameOver.SetActive(true);
            canvasReading.SetActive(false);
            canvasQuiz.SetActive(false);
            canvasShop.SetActive(false);
            kunci = true;
        }
    }

    public void Finish()
    {
        canvasQuiz.SetActive(true);
        canvasReading.SetActive(false);
        finish = true;
        readingVersion =+ 1;
        textReading.text = reading[readingVersion];
        currentTimeInt = Mathf.RoundToInt(currentTime);

        int previousScore = PlayerPrefs.GetInt("Score");
        thenScore = currentTimeInt + previousScore;
        PlayerPrefs.SetInt("Score", thenScore);

    }

    public void ShopYes()
    {
        int previousScore = PlayerPrefs.GetInt("Score");
        if(previousScore >= 10)
        {
            previousScore -= 10;
            PlayerPrefs.SetInt("Score", previousScore);
            boldScript.FormatBionic();
            canvasShop.SetActive(false);
            canvasReading.SetActive(true);
        }
        else
        {
            StartCoroutine(insufficientDisplay());
        }

    }

    public void ShopNo()
    {
        canvasShop.SetActive(false);
        canvasReading.SetActive(true);
    }

    private IEnumerator insufficientDisplay()
    {
        insufficient.SetActive(true);
        canvasShop.SetActive(false);
        yield return new WaitForSeconds(2);
        insufficient.SetActive(false);
        canvasReading.SetActive(true);
    }

    public void Restart()
    {
        string sceneNow;
        sceneNow = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneNow);
        PlayerPrefs.SetInt("Score", 0);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
