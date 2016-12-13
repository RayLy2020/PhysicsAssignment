using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterPad : MonoBehaviour {

    public GameObject player;
    [SerializeField] float speed;
    PlayerController pc;
    Rigidbody rb;

    [SerializeField] AudioSource aud;
    [SerializeField] AudioClip zoom;

    // Use this for initialization
    void Start ()
    {
        pc = player.gameObject.GetComponent<PlayerController>();
        rb = player.gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            aud.clip = zoom;
            aud.Play();
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            pc.boosted = true;
            pc.AcceptsControls = false;
            rb.velocity = new Vector3(speed, 0, 0);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        
    }
}
