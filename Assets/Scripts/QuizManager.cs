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
    int[] arrayOpsiA = {0,1};
    int[] arrayOpsiB = {3};
    int[] arrayOpsiC = {2,4,5};
    int[] arrayOpsiEnd = { 2, 5 };


    private void Start()
    {
        textVersion = 0;
        GantiTextSoalJawaban();
    }

    private void Update()
    {
        int scoreTemp = PlayerPrefs.GetInt("Score");
    }

    public void Correct()
    {
        int scoreTemp = PlayerPrefs.GetInt("Score");
        scoreTemp += 5;
        PlayerPrefs.SetInt("Score", scoreTemp);
    }

    public void Wrong()
    {
        int scoreTemp = PlayerPrefs.GetInt("Score");
        scoreTemp -= 10;
        PlayerPrefs.SetInt("Score", scoreTemp);
    }


    public void ButtonPressed()
    {
        Debug.Log("ButtonPressed");
        textVersion += 1;
        questionIndex = textVersion - 1; //mempermudah coding. Question index menunjukan pertanyaan ke berapa yang muncul.
        GantiTextSoalJawaban();
        CheckPilihan();

    }

    public void CheckPilihan()
    {
        if (arrayOpsiEnd.Contains(questionIndex)) //When Question Ends
        {
            gameManagerScript.finish = false;
            canvasShop.SetActive(true);
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
