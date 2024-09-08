using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    private GameUI gameUI;

    public Action GameWon;
    public Action GameLost;
    public Action LivesCountChanged;
    public Action ScoreChanged;

    private List<IResetable> resetables;
    private List<Block> blocks;

    public int LivesCount { get; private set; } = 3;
    public int Score { get; private set; } = 0;

    private void Start()
    {
        resetables = new();
        blocks = new();

        var roots = SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (var root in roots) { 
            resetables.AddRange(root.GetComponentsInChildren<IResetable>());
            blocks.AddRange(root.GetComponentsInChildren<Block>());
        }

        foreach (var block in blocks) {
            block.Destroyed += b => {
                blocks.Remove(b);
                Destroy(b.gameObject);
                Score += b.ScoreCost;
                ScoreChanged?.Invoke();
                CheckForWin();
            };
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            Reset();
        }
    }

    private void CheckForWin()
    {
        if (blocks.Count == 0) {
            Reset();
            GameWon?.Invoke();
            Debug.LogWarning("Game Won");
        }
    }

    private void Reset()
    {
        foreach (var r in resetables) {
            r.Reset();
        }
    }

    public void BallLost()
    {
        LivesCount--;
        LivesCountChanged?.Invoke();
        Reset();

        if (LivesCount == 0) {
            GameLost?.Invoke();
            Debug.LogWarning("Game Lost");
        }

    }

    public void Pause(bool isPause)
    {
        Time.timeScale = isPause ? 0 : 1;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;

    }
}
