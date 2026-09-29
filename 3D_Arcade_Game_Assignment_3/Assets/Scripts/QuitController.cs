using UnityEngine;

public class QuitController : MonoBehaviour
{
public void QuitGame()
    {
        Debug.Log("Quit Button Clicked");
        Application.Quit();
    }

}
