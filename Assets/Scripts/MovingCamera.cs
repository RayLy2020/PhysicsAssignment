using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour {

    public static int movespeed = 3;
    public Vector3 userDirection = Vector3.right;

    public void Start()
    {

    }
    public void Update()
    {
        transform.Translate(userDirection * movespeed * Time.deltaTime);
    }

}
