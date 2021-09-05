using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    void OnMouseDown() 
    {
        //When someone clicks on the enemy, change it's color
        GetComponent<SpriteRenderer>().color = new Color(1, 0.5f, 0.5f);
    }
}
