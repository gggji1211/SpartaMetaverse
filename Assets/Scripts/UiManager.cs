using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTxet;
    public TextMeshProUGUI Restart;
    void Start()
    {
        if (Restart == null)
            Debug.LogError("æ»µ≈ ≥Œ¿Ãæﬂ");



        Restart.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        Restart.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreTxet.text = score.ToString();
    }
}
