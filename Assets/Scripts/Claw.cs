using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour {

    public GameObject Parent;
    public GameObject Marker;
    public GameObject Player;
    Vector3 Distance;
    bool Attach = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player.transform.SetParent(null);
            Attach = false;
            Player.GetComponent<Rigidbody>().useGravity = true; 

        }

        if (Attach)
        {
            Player.transform.position = gameObject.transform.position - Distance;
            this.gameObject.GetComponent<Rigidbody>().AddForce(0, 10, 0);
            Parent.GetComponent<Rigidbody>().velocity = new Vector3(4, 0, 0);
            if(this.gameObject.transform.position.x >= Marker.transform.position.x)
            {
                Player.transform.SetParent(null);
                Attach = false;
                Player.GetComponent<Rigidbody>().useGravity = true;
            }
        }

        if (Attach == false)
        {
            Parent.GetComponent<Rigidbody>().velocity = new Vector3(-4, 0, 0);
        }


    }

   private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.SetParent(this.transform);
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.GetComponent<PlayerController>().AcceptsControls = false;
            Distance = gameObject.transform.position - other.transform.position;
            Attach = true;
            
        }

    }





}
