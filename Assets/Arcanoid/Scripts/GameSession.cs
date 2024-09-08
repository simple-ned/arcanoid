using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    private List<IResetable> resetables;

    private void Start()
    {
        resetables = new();

        foreach (var root in SceneManager.GetActiveScene().GetRootGameObjects()) { 
            resetables.AddRange(root.GetComponentsInChildren<IResetable>());
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
        foreach (var r in resetables) { 
            r.Reset();
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
