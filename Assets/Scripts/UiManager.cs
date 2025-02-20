using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTxet;
    public TextMeshProUGUI Restart;
    void Start()
    {

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
    public void ChangeToSampleScene()
    {
        GameManager.Instance.SaveScore(); 
        SceneManager.LoadScene("SampleScene"); 
    }
    

}
