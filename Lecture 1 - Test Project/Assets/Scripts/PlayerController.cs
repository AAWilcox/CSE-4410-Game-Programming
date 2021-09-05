using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    //Holds player input (left or right(x), up or down(y))
    Vector2 input;
    //Reference to rigid body
    Rigidbody2D body;
    //Reference to ball
    public GameObject ball;
    //Player has HP
    public float maxHP;
    [SerializeField]
    float hp;
    //Reference to UI player health bar
    public Image healthBar;
    //Text for the money UI
    public Text moneyText;
    //Keeps track of how much money the player has
    int money;
    //Our game controller - used to keep track of money throughout scenes
    GameController cont;

    // Start is called before the first frame update
    //Called when an object is first created, and is only called once
    //Good for initializing variables
    void Start()
    {
        
    }

    //Called before Start()
    void Awake()
    {
        //Save the money value between levels
        cont = FindObjectOfType<GameController>();

        //Get rigid body of sprite
        body = GetComponent<Rigidbody2D>();

        //When a player spawns, they have maxHP
        hp = maxHP;
    }

    // Update is called once per frame
    //Good for constant checks on something (like player input)
    void Update()
    {
        //Get horizontal and vertical input from player
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //If the player presses a, d, left, or right arrows (player moves horizontally)
        if (input.x != 0)
        {
            //If input.x greater than zero, push to right
            //If input.x less than zero, push to left
            //transform.position += Vector3.right * speed * input.x;

            //BETTER METHOD
            //Time.deltaTime helps with correct input during lag
            body.AddForce(Vector2.right * speed * input.x * Time.deltaTime);
        }
        //If the player presses w, s, up, or down arrows (player moves vertically)
        if (input.y != 0)
        {
            body.AddForce(Vector2.up * speed * input.y * Time.deltaTime);
        }

        //If the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Spawn a ball into the scene
            //(Spawn in what?, What position?, What rotation?)
            Instantiate(ball, transform.position, Quaternion.identity);
        }

        //Change the healthbar UI
        healthBar.fillAmount = (hp / maxHP);

        //Update money every frame
        //OLD METHOD - for money on a single scene
        //moneyText.text = "x" + money.ToString();
        moneyText.text = "x" + cont.money.ToString();
    }

    //Player is damaged when they get hit by an enemy
    void OnCollisionEnter2D(Collision2D collision)
    {
        //If the player collides with a gameObject with the tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hp -= 15;
        }
    }

    //If we hit a coin, add it to player's money
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            //Add to player's money
            //OLD METHOD - for money in a single scene
            //money++;
            cont.money++;

            //Set coin's active to false
            collision.gameObject.SetActive(false);
            //Another option:
            //Destroy(collision.gameObject);
        }
    }
}
