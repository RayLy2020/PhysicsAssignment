using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnContact : MonoBehaviour {

    [SerializeField] AudioClip fanfare;
    [SerializeField] AudioSource aud;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            aud.clip = fanfare;
            aud.Play();
            Invoke("EndGame", 8);
        }
    }

    void EndGame()
    {
        Application.Quit();
    }
}
