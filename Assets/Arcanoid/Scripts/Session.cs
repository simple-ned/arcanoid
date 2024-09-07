using UnityEngine;
using UnityEngine.SceneManagement;

public class Session : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
