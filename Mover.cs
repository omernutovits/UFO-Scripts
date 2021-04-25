using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public int speed;
    public string direction = "left-right";
    private Rigidbody2D rb2d;
    private Vector2 velocity;
    
    // Start is called before the first frame update
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        if (direction == "left-right") 
            velocity = new Vector2(1, 0);
        else if (direction == "up-down")
            velocity = new Vector2(0, 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.velocity = velocity * speed;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            velocity = -velocity;
        }
        

    }
    
    
}
