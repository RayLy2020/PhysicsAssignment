using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinballBehaviour : MonoBehaviour {

    [SerializeField] float rotateSpeed;
    [SerializeField] float implosionForce;

    public GameObject player;

    [SerializeField] bool imposeGravity = false;

    Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        rb.angularVelocity = new Vector3(0, rotateSpeed, 0);
        if(imposeGravity)
        {
            Vector3 temp = this.gameObject.transform.position - player.transform.position;
            player.GetComponent<Rigidbody>().velocity = temp.normalized * implosionForce;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            imposeGravity = false;
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            imposeGravity = true;
        }
    }
}
