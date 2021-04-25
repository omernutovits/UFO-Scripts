using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Level : MonoBehaviour
{

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            /*this.gameObject.GetComponent<Renderer>().enabled = false;*/
            /*StartCoroutine(waitBeforeFinish());*/
            Invoke(nameof(nextScene), 3);

        }
    }

    private void nextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex != 3)   // need to check if its last scene
            SceneManager.LoadScene(sceneBuildIndex: SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(sceneBuildIndex: 0);
    }
}
