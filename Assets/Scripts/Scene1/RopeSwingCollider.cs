using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSwingCollider : MonoBehaviour {

    /// <summary>
    /// when you get good, use a line trace to thingy
    /// </summary>
    [SerializeField] GameObject joint;
    [SerializeField] GameObject player;
    [SerializeField] GameObject ball;

    bool look = false;
    bool returntostart = false;
    SpringJoint sprj;
    float speed = 10;
    float startTime;
    Quaternion startRotation;
    float journeyLength;

	// Use this for initialization
	void Start ()
    {
        sprj = joint.GetComponent<SpringJoint>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(look)
        {
            ball.transform.LookAt(player.transform);
        }
        if(Input.GetKeyDown(KeyCode.Space) && sprj.connectedBody != null)
        {
            sprj.connectedBody = null;
            player.GetComponent<PlayerController>().jumpCounter = 0;
            look = false;


            startTime = Time.time;
            startRotation = ball.transform.rotation;
            journeyLength = 10;
            returntostart = true;
        }
        if(returntostart)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            ball.transform.rotation = Quaternion.Lerp(startRotation, Quaternion.Euler(90, 0, 0), fracJourney);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            look = true;
            sprj.connectedBody = player.GetComponent<Rigidbody>();
        }
    }
}
