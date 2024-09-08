using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    public Action GameWon;
    public Action GameLost;

    private List<IResetable> resetables;
    private List<Block> blocks;

    public int LivesCount { get; private set; } = 3;

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
            block.WasHit += b => {
                blocks.Remove(b);
                Destroy(b.gameObject);
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
        Application.Instance.UIManager.UpdateUI();

        if (LivesCount > 0) {
            Reset();
        } else { 
            GameLost?.Invoke();
            Debug.LogWarning("Game Lost");
        }
    }
}
