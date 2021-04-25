using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public int rotate_speed = 45;
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotate_speed) * Time.deltaTime);    
    }
}
