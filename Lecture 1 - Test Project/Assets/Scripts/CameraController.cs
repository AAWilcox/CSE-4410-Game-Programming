using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Reference to transform
    public Transform target;
    //lerp = linear interpolation
    public float lerpSpd;
    void FixedUpdate() 
    {
        //On every frame, change camera's position to target's position
        //WITHOUT lerpSpd
        //transform.position = new Vector3(target.position.x, target.position.y, -10);
        //WITH lerpSpd - changes camera position over time instead of all at once
        //Makes the camera follow less fixed on the player
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, -10), lerpSpd * Time.fixedDeltaTime);
    }
}
