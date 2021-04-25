using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle_movment : MonoBehaviour
{

    public Transform rotationCenter;
    public float speed, radius;
    private float posX, posY, angle = 0;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        posX = rotationCenter.position.x + Mathf.Cos(angle) * radius;
        posY = rotationCenter.position.y + Mathf.Sin(angle) * radius;
        transform.position = new Vector2(posX, posY);
        angle = angle + Time.deltaTime * speed;
        if (angle >= 360)
            angle = 0;
    }
    
}
