using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //To keep track of player score
    public int p1Score;
    public int p2Score;
    //Create a reference to score text
    public Text scoreText;
    //Score value to end the game
    //public int scoreToWin;

    public void Score(bool p1)
    {
        //P1 scored
        if (p1)
        {
            p1Score++;
            //Player 1 won
            //if (p1Score >= scoreToWin) 
            //{

            //}
        }
        //P2 scored
        else
        {
            p2Score++;
        }

        //Update score text
        scoreText.text = p1Score.ToString() + " : " + p2Score.ToString(); 
    }
}
