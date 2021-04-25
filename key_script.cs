using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_script : MonoBehaviour
{
    public GameObject gate;
    // Start is called before the first frame update


    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gate.SetActive(!gate.activeSelf);
            this.gameObject.SetActive(false);
        }
    }

}
