using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AE_StartScene : MonoBehaviour
{

    public Animator animatorLoadingHitamStart;
    public Canvas canvasLoadingHitam;

    private void Start()
    {
        animatorLoadingHitamStart.SetBool("LoadingHitamStart", true);
    }

    public void AE_ChangeSortOrder()
    {
        canvasLoadingHitam.sortingOrder = 0;
    }
}
