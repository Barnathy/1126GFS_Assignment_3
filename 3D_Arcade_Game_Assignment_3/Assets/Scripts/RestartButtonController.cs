using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonController : MonoBehaviour
{
void Start()

    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
public void RestartGame()
    {
       Debug.Log("Restart Button Clicked");
        SceneManager.LoadScene("Level_1");
    }
}

