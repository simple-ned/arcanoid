using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI livesLabel;

    private GameSession session => Application.Instance.Session;

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI() 
    {
        livesLabel.text = session.LivesCount.ToString();
    }
}
