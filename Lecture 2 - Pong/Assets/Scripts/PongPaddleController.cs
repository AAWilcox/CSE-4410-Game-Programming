using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPaddleController : MonoBehaviour
{
    public bool p1;
    public float spd;
    Rigidbody2D bod;

    private void Awake()
    {
        bod = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Player 1 controls
        if (p1)
        {
            //Player 1 pressed W
            if (Input.GetKey(KeyCode.W))
            {
                //Move Player 1's paddle up
                bod.AddForce(Vector2.up * spd * Time.deltaTime);
            }
            //Player 1 pressed S
            if (Input.GetKey(KeyCode.S))
            {
                //Move Player 1's paddle down
                bod.AddForce(-Vector2.up * spd * Time.deltaTime);
            }
        }
        //Player 2 controls
        else
        {
            //Player 2 pressed up arrow
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //Move Player 2's paddle up
                bod.AddForce(Vector2.up * spd * Time.deltaTime);
            }
            //Player 2 pressed down arrow
            if (Input.GetKey(KeyCode.DownArrow))
            {
                //Move Player 2's paddle down
                bod.AddForce(-Vector2.up * spd * Time.deltaTime);
            }
        }
    }
}