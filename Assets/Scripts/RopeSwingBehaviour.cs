using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSwingBehaviour : MonoBehaviour {

    [SerializeField] float swingDelay;
    [SerializeField] GameObject marker1;
    [SerializeField] GameObject marker2;
    [SerializeField] int state = 0; //0 stationary left, 1 moving right, 2 stationairy right, 3 moving left
    [SerializeField] float speed = 5;

    float startTime;
    float journeyLength;
    float distCovered;
    float fracJourney;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		switch(state)
        {
            case 0:
                transform.rotation = marker1.transform.rotation;
                break;
            case 1:
                startTime = Time.time;
                journeyLength = marker2.transform.rotation.z - marker1.transform.rotation.z;
                distCovered = (Time.time - startTime) * speed;
                fracJourney = distCovered / journeyLength;
                transform.rotation = Quaternion.Lerp(marker1.transform.rotation, marker2.transform.rotation, fracJourney);
                break;
            case 2:
                this.gameObject.transform.position = marker2.transform.position;
                break;
            case 3:
                startTime = Time.time;
                journeyLength = marker1.transform.rotation.z - marker2.transform.rotation.z;
                distCovered = (Time.time - startTime) * speed;
                fracJourney = distCovered / journeyLength;
                transform.rotation = Quaternion.Lerp(marker2.transform.rotation, marker1.transform.rotation, fracJourney);
                break;
        }
        if(transform.rotation == marker2.transform.rotation)
        {

        }
	}

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
        }
    }
}
