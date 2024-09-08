using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
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
            };
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            Reset();
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            Restart();
        }
    }

    public void Reset()
    {
        LivesCount--;
        Application.Instance.UIManager.UpdateUI();

        foreach (var r in resetables) { 
            r.Reset();
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
    }

    
}
