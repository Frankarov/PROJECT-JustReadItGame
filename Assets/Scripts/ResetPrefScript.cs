using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPrefScript : MonoBehaviour
{

    public void ResetPref()
    {
        PlayerPrefs.SetInt("Score", 0);
    }


}
