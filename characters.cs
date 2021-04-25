using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characters : MonoBehaviour
{
    // Start is called before the first frame update
    public void chooseUFO()
    {
        Debug.Log("ufo");
        PlayerPrefs.SetInt("character", 0);
        PlayerPrefs.SetInt("HighScoreUFO", 0);
    }
       

    public void chooseRocket()
    {
        Debug.Log("rocket");
        PlayerPrefs.SetInt("character", 1);
        PlayerPrefs.SetInt("HighScoreRocket", 0);
    }

    // Update is called once per frame
    
}
