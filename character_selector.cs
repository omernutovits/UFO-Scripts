using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character_selector : MonoBehaviour
{
    int character;
    int score;
    public GameObject[] characters;
    
    [SerializeField] private int pref_choise = -1;
    // Start is called before the first frame update
    void Start()
    {
        characters[0].SetActive(false);
        characters[1].SetActive(false);
        if (pref_choise == -1)
        {
            character = PlayerPrefs.GetInt("character");
            characters[character].SetActive(true);
            switch (character)
            {
                case 0: score = PlayerPrefs.GetInt("HighScoreUFO"); break;
                case 1: score = PlayerPrefs.GetInt("HighScoreRocket"); break;
            }

        }
        else // for debug select
        {
            characters[pref_choise].SetActive(true);
        }

        
    }

    // Update is called once per frame
   
}
