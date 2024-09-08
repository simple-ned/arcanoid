using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Application : MonoBehaviour
{
    public static Application Instance { get; private set; }
    public GameUI UIManager { get; private set; }

    private int numberOfLevels = 3;


    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }

        UIManager = FindObjectOfType<GameUI>();

        DontDestroyOnLoad(gameObject);
    }

    public void LoadLevel(int level) {
        SceneManager.LoadSceneAsync(level);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        UnityEngine.Application.Quit();
    }

    internal void TryLoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex <= numberOfLevels) {
            SceneManager.LoadScene(nextSceneIndex);
        } else { 
            LoadMainMenu();
        }
    }
}
