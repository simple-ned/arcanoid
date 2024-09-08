using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI livesLabel;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private GameObject GameLostPanel;

    [SerializeField]
    private GameObject GameWonPanel;

    [SerializeField]
    private GameObject GamePausePanel;

    [SerializeField]
    private GameSession session;

    private void Start()
    {
        UpdateUI();
        session.LivesCountChanged += () => UpdateUI();
        session.ScoreChanged += () => UpdateUI();
        session.GameWon += () => ShowGameWonMenu();
        session.GameLost += () => ShowGameLostPanel();
    }

    public void UpdateUI()
    {
        livesLabel.text = session.LivesCount.ToString();
        scoreText.text = session.Score.ToString();
    }

    public void ShowGameLostPanel()
    {
        GameLostPanel.SetActive(true);
        session.Pause(true);
    }

    public void ShowGameWonMenu()
    {
        GameWonPanel.SetActive(true);
        session.Pause(true);
    }

    public void ShowPauseMenu(bool isPause)
    {
        GamePausePanel.SetActive(isPause);
        session.Pause(isPause);
    }

    public void ReturnToMainMenu() { 
        Application.Instance.LoadMainMenu();
    }

    public void RetryLevel()
    {
        Application.Instance.ReloadLevel();
    }

    public void LoadNextLevel()
    {
        Application.Instance.TryLoadNextLevel();
    }
}
