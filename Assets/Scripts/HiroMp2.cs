using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiroMp2 : MonoBehaviour {

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
            rb.velocity = new Vector3(thrust, 0, 0);
        }

        if (HitBPoint == true)
        {
            rb.velocity = new Vector3(-thrust, 0, 0);
        }

        if (rb.transform.position.x <= APoint.transform.position.x)
        {
            //rb.velocity = Vector3.zero;
            HitBPoint = false;
        }

        if (rb.transform.position.x >= BPoint.transform.position.x)
        {
            //rb.velocity = Vector3.zero;
            HitBPoint = true;
        }

    }
}
