using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HotKeys : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    KeyCode keyRestart;
    [SerializeField]
    KeyCode keyEscape;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyRestart))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else if (Input.GetKey(keyEscape))
            SceneManager.LoadScene(sceneBuildIndex: 0);
        
    }
}
