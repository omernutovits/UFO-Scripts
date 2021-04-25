using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firewallScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<Renderer>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
    }
}
