using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhichButtonPressed : MonoBehaviour
{

    public QuizManager quizManagerScript;

    public void ClickedAndCheck()
    {
        Debug.Log("CheckWhichButtonPressed");
        if (gameObject.CompareTag("opsiA"))
        {
            quizManagerScript.whichButtonPressed = 1;
        }else if (gameObject.CompareTag("opsiB"))
        {
            quizManagerScript.whichButtonPressed = 2;
        }else if (gameObject.CompareTag("opsiC"))
        {
            quizManagerScript.whichButtonPressed = 3;
        }
    }

}
