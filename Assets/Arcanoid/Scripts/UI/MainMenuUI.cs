using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    private GameObject MainMenu;

    [SerializeField]
    private GameObject LevelsPanel;

    public void LoadLevel(int level)
    {
        Application.Instance.LoadLevel(level);
    }

    public void ShowLevels(bool isShow)
    {
        MainMenu.SetActive(!isShow);
        LevelsPanel.SetActive(isShow);
    }

    public void Exit() {
        Application.Instance.Exit();
    }
}
