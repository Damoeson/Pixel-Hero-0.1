using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Move : MonoBehaviour
{
    public int sceneBuildIndex;
    public Animator FadeSystem;
    public Collider2D Triggercollider2D;

    private void Awake()
    {
        FadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }


    // Level move zoned enter, if collider is a player
    // Move game to another scene
    private void OnTriggerEnter2D(Collider2D Triggercollider2D)
    {
        print("Trigger Entered");

        // Could use other.GetComponent<Player>() to see if the game object has a Player component
        // Tags work too. Maybe some players have different script components?
        if (Triggercollider2D.tag == "Player")
        {
            StartCoroutine(LoadNextScene());
        }
    }

    public IEnumerator LoadNextScene()
    {
        FadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        // Player entered, so move level
        print("Switching Scene to " + sceneBuildIndex);
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}
