using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitController : MonoBehaviour
{
        private void OnTriggerEnter(Collider other) //when the player collides with an enemy, this function is called
    {
        if (other.CompareTag("Player"))
        {
       
            Debug.Log("You Win!"); // log win message
            SceneManager.LoadScene("Win"); // load the Win scene*/
        }
    }
}
