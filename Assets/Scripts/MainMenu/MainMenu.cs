using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Animator animatorLoadingHitam;
    public Canvas canvasLoadingHitam;

    public void StartButton()
    {
        animatorLoadingHitam.SetBool("LoadingHitam", true);
        canvasLoadingHitam.sortingOrder = 2;
    }

    public void ExitButton()
    {
        Application.Quit();
    }


}
