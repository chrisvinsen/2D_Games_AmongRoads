using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    public float speed;
    private bool long_idle = false;
    private float timeToIdle = 2.0f; //2 seconds
    float currentTime = 0f;
    private bool isAlive;

    void Start()
    {
        isAlive = true;
        ScoreScript.scoreValue = 0;
        animator = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        currentTime = Time.time + timeToIdle;

        if (speed == 0)
        {
            speed = 5f;
        }

    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        
        if (isAlive){
            if (!long_idle)
                checkIdle();
            if (Input.anyKey)
            {
                long_idle = false;
                animator.SetBool("long_idle", false);
                currentTime = Time.time + timeToIdle;
            }

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            if (h != 0f)
            {
                animator.SetFloat("walk", Mathf.Abs(h));
                this.transform.Translate(new Vector2(h, 0) * speed * Time.deltaTime);
                if (h < 0f)
                    spriteRenderer.flipX = true;
                else
                    spriteRenderer.flipX = false;
            }
            if (v != 0f)
            {
                animator.SetFloat("walk", Mathf.Abs(v));
                this.transform.Translate(new Vector2(0, v) * speed * Time.deltaTime);
            }
        }
    }

    void checkIdle()
    {
        if (Time.time > currentTime)
        {
            long_idle = true;
            animator.SetBool("long_idle", true);
        } 
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Car")
        {
            isAlive = false;
            animator.SetBool("die", true);
            StartCoroutine(goToDefeatScreen(3));
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Score")
        {
            if (ScoreScript.scoreValue < System.Convert.ToInt32(col.gameObject.name))
            {
                ScoreScript.scoreValue = System.Convert.ToInt32(col.gameObject.name);
            }
        }
        if (col.gameObject.name == "Finish") {
            StartCoroutine(goToVictoryScreen(0));
        }
    }

    IEnumerator goToVictoryScreen(int second) {
        yield return new WaitForSeconds(second);
        SceneManager.LoadScene(2);
    }
    IEnumerator goToDefeatScreen(int second) {
        yield return new WaitForSeconds(second);
        SceneManager.LoadScene(3);
    }
}