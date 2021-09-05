using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//We are using this to carry the money value across scenes
public class GameController : MonoBehaviour
{
    //Money value carried across scenes
    public int money;

    //Only one game controller in any scene
    public static GameController cont;

    void Awake()
    {
        //If there's no a game controller
        if (cont == null)
        {
            //Set a controller
            cont = this;
            DontDestroyOnLoad(gameObject);
        }
        //There is already a game controller
        else{
            Destroy(gameObject);
        }
    }
}
