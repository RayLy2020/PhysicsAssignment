using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootKirby : MonoBehaviour {

    public Rigidbody rb;
    public int thrust;

	// Use this for initialization
	void Start () {
        rb.maxAngularVelocity = 1000000;
	}
	
	// Update is called once per frame
	
     void Update () {
		if(Input.GetKeyDown(KeyCode.X))
        {
            transform.parent = null;
            rb.useGravity = true;
            rb.angularVelocity = new Vector3(0, 0, -thrust);
        }
	}
     
}
