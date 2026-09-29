using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ExitController : MonoBehaviour

{
    public TMP_Text winText; // reference to the TextMeshProUGUI component that displays the win message
    public ParticleSystem playparticle; // reference to the ParticleSystem component that plays the particle effect

    private void OnTriggerEnter(Collider other) //when the player collides with an enemy, this function is called
    {
        if (other.CompareTag("Player"))
        {
            playparticle.Play(); // play the particle effect
            Debug.Log("You Win!"); // log win message
            winText.gameObject.SetActive(true); // call the function to enable the win text


            StartCoroutine(LoadWinSceneAfterDelay(1f)); // start a coroutine to load the Win scene after a delay
        }
    }

    private System.Collections.IEnumerator LoadWinSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Win");
    }
}
