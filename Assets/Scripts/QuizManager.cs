using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class QuizManager : MonoBehaviour
{
    public GameObject canvasReading;
    public GameObject canvasQuiz;
    public GameObject canvasShop;

    public TMP_Text textSoal;
    public TMP_Text textOpsiA;
    public TMP_Text textOpsiB;
    public TMP_Text textOpsiC;
    public GameManager gameManagerScript;
    public BoldScript boldScript;

    [SerializeField]
    private int textVersion;
    [SerializeField]
    private int questionIndex;
    public int whichButtonPressed = 0;

    //Isi text
    public string[] soal;
    public string[] opsiA;
    public string[] opsiB;
    public string[] opsiC;

    //KunciJawaban
    int[] arrayOpsiA = { 0, 1, 4, 8, 12, 19, 21, 24, 29 };
    int[] arrayOpsiB = { 2, 3, 5, 6, 7, 9, 10, 13, 15, 16, 17, 22, 23, 25, 26, 27, 28 };
    int[] arrayOpsiC = { 11, 14, 18, 20 };
    int[] arrayOpsiEnd = { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29 };

    public GameObject scorePanel;
    public TMP_Text finishGameText;

    private int questionnaireScore = 0;
    private int finalScore = 0;

    private void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        textVersion = 0;
        GantiTextSoalJawaban();
    }

    private void Update()
    {
        int scoreTemp = PlayerPrefs.GetInt("Score");
    }

    public void Correct()
    {
        int prevScore = PlayerPrefs.GetInt("Score");
        int currScore = prevScore + 10;
        PlayerPrefs.SetInt("Score", currScore);
        gameManagerScript.scoreText.text = currScore.ToString();
        questionnaireScore += 10;
    }

    public void Wrong()
    {
        int prevScore = PlayerPrefs.GetInt("Score");
        int currScore = prevScore - 5;
        PlayerPrefs.SetInt("Score", currScore);
        gameManagerScript.scoreText.text = currScore.ToString();
        if (questionnaireScore > 0)
        {
            questionnaireScore -= 5;
        }
            
    }


    public void ButtonPressed()
    {
        Debug.Log("ButtonPressed");


        textVersion += 1;
        Debug.Log(textVersion);
        if (textVersion >= soal.Length)
        {
            if (questionnaireScore < 0)
            {
                questionnaireScore = 0;
            }

            if (PlayerPrefs.GetInt("Score") < 0)
            {
                PlayerPrefs.SetInt("Score", 0);
            }

            finalScore = Mathf.RoundToInt((gameManagerScript.timeScore + questionnaireScore));
            if (finalScore > 300 && finalScore<450)
            {
                finishGameText.text = "Good";
            }
            else if(finalScore>450)
            {
                finishGameText.text = "Excellent";
            }
            else
            {
                finishGameText.text = "You need to practice more";
            }

            canvasQuiz.SetActive(false);
            scorePanel.SetActive(true);
            scorePanel.transform.GetChild(3).transform.GetComponent<TMPro.TMP_Text>().text = "Final Score : " + finalScore;
            scorePanel.transform.GetChild(1).transform.GetComponent<TMPro.TMP_Text>().text = "Reading Speed Score        : " + gameManagerScript.timeScore;
            scorePanel.transform.GetChild(2).transform.GetComponent<TMPro.TMP_Text>().text = "Reading Comprehension Score: " + questionnaireScore;
            return;
        }

        questionIndex = textVersion - 1; //mempermudah coding. Question index menunjukan pertanyaan ke berapa yang muncul.
        GantiTextSoalJawaban();
        CheckPilihan();

    }

    public void CheckPilihan()
    {
        if (arrayOpsiEnd.Contains(questionIndex)) //When Question Ends
        {
            gameManagerScript.currentTime = 30;
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 3)
            {
                boldScript.FormatBionic();
            }
            gameManagerScript.finish = false;
            canvasReading.SetActive(true);
            canvasQuiz.SetActive(false);
        }
        else
        {
            boldScript.enabled = false;
        }


        if (arrayOpsiA.Contains(questionIndex))
        {
            if (whichButtonPressed == 1)
            {
                Correct();
            }
            else
            {
                Wrong();
            }
        }
        else if (arrayOpsiB.Contains(questionIndex))
        {
            if (whichButtonPressed == 2)
            {
                Correct();
            }
            else
            {
                Wrong();
            }
        }
        else if (arrayOpsiC.Contains(questionIndex))
        {
            if (whichButtonPressed == 3)
            {
                Correct();
            }
            else
            {
                Wrong();
            }
        }
    }

    public void GantiTextSoalJawaban()
    {
        textSoal.text = soal[textVersion];
        textOpsiA.text = opsiA[textVersion];
        textOpsiB.text = opsiB[textVersion];
        textOpsiC.text = opsiC[textVersion];
    }
}
