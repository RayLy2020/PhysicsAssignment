using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform1 : MonoBehaviour {

    public Transform marker1;
    public Transform marker2;
    public Transform marker3;

    public GameObject player;

    int state = 1;

    //float startTime;
    //float journeyLength;
    [SerializeField] float speed = 10;

    Rigidbody rb; 


	// Use this for initialization
	void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        /*if (state == 1 && parent.position == marker1.position)
        {
            state = 0;
            startTime = Time.time;
            journeyLength = Vector3.Distance(marker1.position, marker2.position);
        }
        if (state == 0)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            parent.position = Vector3.Lerp(marker1.position, marker2.position, fracJourney);
        }

        if(state == 0 && parent.position == marker2.position)
        {
            state = 1;
            startTime = Time.time;
            journeyLength = Vector3.Distance(marker2.position, marker1.position);
        }
        if(state ==1)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            parent.position = Vector3.Lerp(marker2.position, marker1.position, fracJourney);
        }*/

        if(state == 1 && transform.position.x <= marker1.position.x)
        {
            state = 0;
            rb.constraints = ~RigidbodyConstraints.FreezePositionX;
            if(player.transform.parent == this.gameObject.transform)
            {
                state = 2;
                rb.constraints = ~RigidbodyConstraints.FreezePositionY;
            }
        }
        if(state == 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        if(state == 0 && transform.position.x >= marker2.position.x)
        {
            state = 1;
            rb.constraints = ~RigidbodyConstraints.FreezePositionX;
        }
        if(state == 1)
        {
            rb.velocity = new Vector3(-speed, 0, 0);
        }
        if(state == 2)
        {
            rb.velocity = new Vector3(0, speed, 0);
        }
        if(state == 2 && transform.position.y >= marker3.position.y)
        {
            state = 3;
            rb.constraints = ~RigidbodyConstraints.FreezePositionY;
        }
        if(state == 3)
        {
            rb.velocity = new Vector3(0, -speed, 0);
        }
        if(state == 3 && transform.position.y <= marker1.position.y)
        {
            state = 2;
            rb.constraints = ~RigidbodyConstraints.FreezePositionY;
            if(player.transform.parent != this.gameObject.transform)
            {
                state = 1;
                rb.constraints = ~RigidbodyConstraints.FreezePositionX;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.transform.SetParent(this.gameObject.transform);
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.SetParent(null);
        }
    }
}
