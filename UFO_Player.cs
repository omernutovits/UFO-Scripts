using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UFO_Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    private int count;
    public bool killed;
    public Text countText;
    public Text winText;
    public Text timerText;
    public Text directions_Rocket;
    public Text directions_UFO;
    public Text highScore;
    public float startTime;
    public GameObject animatino;
    public int scene;
    
    void Start()
    {
        killed = false;
        startTime = Time.time;
        scene = SceneManager.GetActiveScene().buildIndex;
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        updateCountText();
        winText.text = "";
        highScore.text = "Highscore:" + PlayerPrefs.GetInt("HighScoreUFO").ToString();
        directions_Rocket.enabled = false;
        if (scene == 1)
        {

            Invoke("DisableText", 4f);
        }
        else
        {
            directions_UFO.text = "";
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
        {
            rb2d.simulated = false;
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movment = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movment * speed);


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
            collision.gameObject.SetActive(false);
            rb2d.velocity = Vector2.zero;
            rb2d.angularVelocity = 0f;
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
        if(count > PlayerPrefs.GetInt("HighScoreUFO"))
        {
            PlayerPrefs.SetInt("HighScoreUFO", count);
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
            Vector2 instantiatePoint = collision.GetContact(0).point;
            Instantiate(animatino, instantiatePoint, Quaternion.identity);
            //Destroy(gameObject);
            StartCoroutine(waitBeforeFinish());

        }
    }
    void DisableText()
    {
        directions_UFO.enabled = false;
    }
}



