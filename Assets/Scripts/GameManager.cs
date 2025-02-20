using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;

    public static GameManager Instance { get { return gameManager; } }

    private int currentScore = 0; // 현재점수
    private int savedScore = 0;   // 씬 이동 후 유지될 점수
    UiManager uiManager;
    public UiManager UiManager { get { return uiManager; } }
    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UiManager>();
        DontDestroyOnLoad(gameObject); // 씬이 변경되어도 GameManager 유지


    }

    public void Start()
    {
        uiManager.UpdateScore(0);
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
        uiManager.SetRestart();
    }

    public void reStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);
    }
    public void SaveScore()
    {
        savedScore = currentScore;
    }
    public int GetSavedScore()
    {
        return savedScore;
    }
    public int GetScore()
    {
        return currentScore;
    }
    
}
