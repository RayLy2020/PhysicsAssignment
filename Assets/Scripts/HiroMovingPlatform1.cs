using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiroMovingPlatform1 : MonoBehaviour {

    public GameObject APoint;
    public GameObject BPoint;
    public bool HitBPoint;

    public float thrust = 5;
    public Rigidbody rb;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (HitBPoint == false)
        {
            rb.velocity = new Vector3(0, thrust, 0);
        }

        if (HitBPoint == true)
        {
            rb.velocity = new Vector3(0, -thrust, 0);
        }

        if (rb.transform.position.y <= APoint.transform.position.y)
        {
            //rb.velocity = Vector3.zero;
            HitBPoint = false;
        }

        if (rb.transform.position.y >= BPoint.transform.position.y)
        {
            //rb.velocity = Vector3.zero;
            HitBPoint = true;
        }

    }

}

