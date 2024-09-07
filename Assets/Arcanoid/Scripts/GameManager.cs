using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

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
