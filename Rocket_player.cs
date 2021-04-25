using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Rocket_player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    private int count;
    public Text countText;
    public Text winText;
    public Text timerText;
    public float startTime;
    public Text directions_UFO;
    public Text directions_Rocket;
    public bool killed;
    public GameObject animatino;
    public Text highScore;
    public int scene;
    
    void Start()
    {
        killed = false;
        startTime = Time.time;
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        updateCountText();
        winText.text = "";
        scene = SceneManager.GetActiveScene().buildIndex;
        directions_UFO.enabled = false;
        highScore.text = "Highscore:" + PlayerPrefs.GetInt("HighScoreRocket").ToString();
        if (scene == 1)
        {
            Invoke("DisableText", 4f);
        }
        else
        {
            directions_Rocket.text = "";
        }
    }

    void Update()
    {
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timerText.text = minutes + ":" + seconds;

    }
    void FixedUpdate()
    {
        if (killed)
            rb2d.simulated = false;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if (moveVertical > 0) {   
            rb2d.AddForce(transform.right * speed);
        } else if (moveVertical < 0)
        {
            rb2d.velocity = rb2d.velocity /= new Vector2 ((float) 1.05, (float) 1.05); 
        }
        if (moveHorizontal != 0)
        {
            transform.Rotate(new Vector3(0, 0, -5) * moveHorizontal);
        } else
        {
            rb2d.freezeRotation = true;
        }
       


    }

   

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            collision.gameObject.SetActive(false);
            count++;
            updateCountText();
        }
        if (collision.gameObject.CompareTag("EndLevel"))
        {
            rb2d.velocity = Vector2.zero;
            rb2d.angularVelocity = 0f;
            collision.gameObject.SetActive(false);
            switch (scene)
            {
                case 1: winText.text = "NICE! Be careful in the next one"; break;
                case 2: winText.text = "CONGRATULATIONS! Soon you will have a cake."; break;
                case 3: winText.text = "No cake for you. it was a lie."; break;
            }
        }
    }

    void updateCountText()
    {
        countText.text = "Score: " + count.ToString();
        if (count > PlayerPrefs.GetInt("HighScoreRocket"))
        {
            PlayerPrefs.SetInt("HighScoreRocket", count);
            highScore.text = "Highscore:" + count.ToString();
        }

    }

    private IEnumerator waitBeforeFinish()
    {
      
            this.gameObject.GetComponent<Renderer>().enabled = false;
            
            winText.text = "YOU PATHETHIC LOSER!";
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            this.gameObject.GetComponent<Renderer>().enabled = true;
        

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("spikes"))
        {
            killed = true;
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            Vector2 instantiatePoint = collision.GetContact(0).point;
            Instantiate(animatino, instantiatePoint, Quaternion.identity);
            //Destroy(gameObject);
            StartCoroutine(waitBeforeFinish()); // plaster achush
        }
        

    }
    void DisableText()
    {
        directions_Rocket.enabled = false;
    }

}



