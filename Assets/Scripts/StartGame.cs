using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject gameCanvas;
    public BoldScript boldScript;
    public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        boldScript.FormatBionic();
        gameCanvas.SetActive(true);
        manager.isStart = true;
        gameObject.SetActive(false);
    }

    public void NormalStartGame()
    {
        gameCanvas.SetActive(true);
        manager.isStart = true;
        gameObject.SetActive(false);
    }
}
