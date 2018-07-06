using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class BallContraler2D : MonoBehaviour
{
    public float thrust = 40.0f;
    private Rigidbody2D rb;
    public GameObject gamover;
    public GameObject explode;
    public Text showscore;
    private int score;



    public AudioSource se;
    public AudioClip platese;
    public AudioClip losese;
    public AudioClip barkse;
    public List<AudioClip> cubese;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            gamover.SetActive(true);
            CubemanController2D.gameover = true;
            //se.clip = losese;
            //se.PlayOneShot(se.clip);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "plate")
        {
            se.clip = platese;
            se.PlayOneShot(se.clip);
            rb.AddForce(new Vector2(Random.Range(-5f, 5f), 10.0f) * thrust);
        }
        if (collision.gameObject.tag == "cube")
        {
            se.clip = cubese[Random.Range(0,cubese.Count - 1)];
            se.PlayOneShot(se.clip);
            GameObject newexplode = Instantiate(explode, collision.gameObject.transform.position, new Quaternion(0, 0, 0, 0));
            newexplode.SetActive(true);
            Destroy(collision.gameObject);
            rb.AddForce(new Vector2(0, 10.0f) * thrust);
            score++;
            showscore.text = score.ToString();
        }
        if (collision.gameObject.tag == "dog")
        {
            se.clip = barkse;
            se.PlayOneShot(se.clip);
            score += 5;
            showscore.text = score.ToString();
        }
        if (collision.gameObject.tag == "al")
        {
            gamover.SetActive(true);
            CubemanController2D.gameover = true;
        }
        //rb.AddForce(new Vector3(Random.Range(-0.2f, 0.2f), 1.0f, 0) * thrust);
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "plate")
    //    {
    //        rb.AddForce(new Vector3(Random.Range(-0.2f, 0.2f), 1.0f, 0) * thrust);
    //    }
    //    //rb.AddForce(new Vector3(Random.Range(-0.2f, 0.2f), 1.0f, 0) * thrust);
    //}
}
