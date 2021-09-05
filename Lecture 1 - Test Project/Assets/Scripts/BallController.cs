using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //Reference to the ball
    Rigidbody2D body;

    //Speed of ball
    public float spd;

    void Awake()
    {
        //Get the ball body
        body = GetComponent<Rigidbody2D>();
    }

    //Control what a ball does once it exists
    //This function is called once
    void OnEnable()
    {
        body.AddForce(Vector2.up * spd);
    }

    //Whenever the "Is Trigger" collider on the ball enters another collider
    void OnTriggerEnter2D(Collider2D collision)
    {
        //If the collision has the wall tag
        if (collision.CompareTag("Wall"))
        {
            //Destroy the ball that collided with the wall
            Destroy(gameObject);
        }
    }
}
