using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gAK : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("COOL");
            col.gameObject.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<Rigidbody>().velocity;
        }
    }

   /* void OnTriggerExit(Collider col)
    { 
        if (gameObject.tag == "Player")
        {
        
        }
    
    }
    */
}
