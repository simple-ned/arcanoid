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

        FindSession();

        UIManager = FindObjectOfType<GameUI>();

        DontDestroyOnLoad(gameObject);
    }

    private void FindSession()
    {
        Session = FindObjectOfType<GameSession>();
    }

    public void BallLost()
    { 
        Session.Reset();
    }

    public void LoadLevel(int level) {
        SceneManager.LoadScene(level);
        FindSession();
    }
}
