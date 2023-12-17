using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMode : MonoBehaviour
{

    public void NormalMode()
    {
        SceneManager.LoadScene(2);
    }

    public void BoldedMode()
    {
        SceneManager.LoadScene(3);
    }
}
