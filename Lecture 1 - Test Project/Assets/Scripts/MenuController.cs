using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Used for our Restart Level Button
public class MenuController : MonoBehaviour
{
    /* All ways to load levels
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
    
    public void LoadFirstLevel()
    {
        //A certain level number
        SceneManager.LoadScene(0);
    }

    public void LoadLevel(int ind)
    {
        //A certain level number
        SceneManager.LoadScene(ind);
    }

    public void LoadLevel(string s)
    {
        //A level name
        SceneManager.LoadScene(s);
    }
    */

    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //buildIndex + 1 is the next scene
    }
}
