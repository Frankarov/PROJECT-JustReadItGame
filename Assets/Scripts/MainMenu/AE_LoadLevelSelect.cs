using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AE_LoadLevelSelect : MonoBehaviour
{

    public void FadeAnimationFinished()
    {
        SceneManager.LoadScene("LevelSelect");
    }


}
