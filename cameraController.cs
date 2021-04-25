using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject[] players;
    public int character;
    private Vector3 offset;
    [SerializeField] private int pref_choise = -1;
    // Start is called before the first frame update
    void Start()
    {
        if (pref_choise == -1)
        {
            character = PlayerPrefs.GetInt("character");
            offset = transform.position - players[character].transform.position;
        }
        else
        {
            offset = transform.position - players[pref_choise].transform.position;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (pref_choise == -1)
        {
            transform.position = players[character].transform.position + offset;
        }
        else 
        {
            transform.position = players[pref_choise].transform.position + offset;
        }
        
    }
}
