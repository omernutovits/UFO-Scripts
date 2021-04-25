using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Dispenser : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fire;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            fire.SetActive(true);
    }

}
