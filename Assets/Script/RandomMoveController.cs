using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMoveController : MonoBehaviour
{
    public float accelerationTime = 2f;
    public float maxSpeed = 10f;
    private Vector2 movement;
    private float timeLeft;
    private Rigidbody2D rb;
 
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

     void Update()
     {
         timeLeft -= Time.deltaTime;
         if(timeLeft <= 0)
         {
             movement = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
             timeLeft += accelerationTime;
         }
     }
 
     void FixedUpdate()
     {
         rb.AddForce(movement * maxSpeed * Time.deltaTime);
     }
}
