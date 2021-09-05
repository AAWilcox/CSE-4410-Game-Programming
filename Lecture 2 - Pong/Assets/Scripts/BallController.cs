using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //Reference to the ball
    Rigidbody2D body;
    //Speed of ball
    public float spd;
    //Used on ball spawn
    public float randomUp;
    //Reference to our game controller
    GameController cont;

    void Awake()
    {
        //Find the game controller when the game starts up
        cont = FindObjectOfType<GameController>();
        //Get the ball body
        body = GetComponent<Rigidbody2D>();
    }

    //Control what a ball does once it exists
    //This function is called once
    void OnEnable()
    {
        //When ball spawns, push the ball randomly
        //Call PushBall() function after 2 seconds
        Invoke("PushBall", 2f);
    }

    //When the ball collides with something
    void OnCollisionEnter2D(Collision2D collision) 
    {
        //Ball hits a player
        if (collision.gameObject.CompareTag("Player")) {
            Vector2 vel;
            //Ball's new x velocity is the same
            vel.x = body.velocity.x;
            //Change the ball's y velocity
            vel.y = (body.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3);
            //Set ball's new velocity
            body.velocity = vel;
        }
    }

    void PushBall()
    {
        //Ball goes in random direction, left or right, when it spawns
        //Randomly chooses numbers between [0, 2)
        int dir = Random.Range(0, 2);
        if (dir == 0) {
            //Ball moves right
            body.AddForce(Vector2.right * spd);
        }
        else {
            //Ball moves left
            body.AddForce(Vector2.left * -spd);
        }

        //Ball randomly goes up or down
        body.AddForce(Vector2.up * Random.Range(-randomUp, randomUp));
    }

    //If a ball touches a goal
    void OnTriggerEnter2D(Collider2D collision)
    {
        //If the ball touches the goal
        if (collision.CompareTag("Goal")) {
            //Player one made a goal (ball is moving to the right)
            if (body.velocity.x > 0) {
                //Player 1 scored
                //Call the score function within GameController.cs
                cont.Score(true);
            }
            else
            {
                //Player 2 scored
                cont.Score(false);
            }

            //Reset ball's velocity
            body.velocity = Vector2.zero;
            //Reset ball's position
            transform.position = new Vector3(0, 0, 0);
            //Call PushBall() function after 2 seconds
            Invoke("PushBall", 2f);
        }
    }
}
