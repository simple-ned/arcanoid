using UnityEngine;

public class Application : MonoBehaviour
{
    public static Application Instance { get; private set; }

    public GameSession Session { get; private set; }

    private void Start()
    {
        if (Instance == null) {
            Instance = this;
        }

        FindSession();

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
}
