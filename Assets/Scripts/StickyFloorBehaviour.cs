using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyFloorBehaviour : MonoBehaviour {

    [SerializeField] GameObject player;

    float oldSpeed;
    [SerializeField] float newSpeed = 3;

	// Use this for initialization
	void Start ()
    {
        oldSpeed = player.GetComponent<PlayerController>().speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerController>().speed = newSpeed;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerController>().speed = oldSpeed;
        }
    }
}
