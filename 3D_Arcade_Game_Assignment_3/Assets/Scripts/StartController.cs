using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{

public void StartGame()
    {
        SceneManager.LoadScene("Level_1");
    }

}
