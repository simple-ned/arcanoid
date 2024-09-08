using UnityEngine;
using UnityEngine.SceneManagement;

public class Application : MonoBehaviour
{
    public static Application Instance { get; private set; }
    public GameSession Session { get; private set; }
    public GameUI UIManager { get; private set; }


    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }

        UIManager = FindObjectOfType<GameUI>();

        DontDestroyOnLoad(gameObject);
    }

    private void FindSession()
    {
        Session = FindObjectOfType<GameSession>();
    }

    public void BallLost()
    { 
        Session.BallLost();
    }

    public void LoadLevel(int level) {
        SceneManager.LoadSceneAsync(level);
        FindSession();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        UnityEngine.Application.Quit();
    }
}
