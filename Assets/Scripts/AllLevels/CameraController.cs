﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    //state
	public int state = 0;
    bool transition0 = false;
    bool transition1 = false;
    bool transition2 = false;

    //transforms
    public GameObject player;
    public Transform position0;
    public Transform position1;
    public Transform position2;
    Vector3 position3;

    //maths
    [SerializeField] float speed = 10f;
    float startTime;
    float journeyLength;
    Quaternion rotationLength;

    //audio
    [SerializeField] AudioSource audBG;
    [SerializeField] AudioSource audEN;
    [SerializeField] AudioClip threeaud;
    [SerializeField] AudioClip twoaud;
    [SerializeField] AudioClip oneaud;
    [SerializeField] AudioClip goaud;
    [SerializeField] AudioClip popaud;

    bool once = false;

    [SerializeField] bool testing; //delete this later

    float temp; //detele this later

	// Use this for initialization
	void Start () 
	{
        temp = player.transform.position.z - 20;
    }
	
	// Update is called once per frame
	void Update () 
	{
        #region Testing
        if (testing)
        {
            state = 4;
            if (player != null)
            {
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 10, temp);
                transform.LookAt(player.transform);
            }
            return;
        }
        #endregion

        #region CheckForCinematic
        if (state != 4)
        {
            player.GetComponent<PlayerController>().AcceptsControls = false;
        }
        #endregion

        #region cinematic1
        if (state == 1)
        {
            if(!transition0)
            {
                transition0 = true;
                startTime = Time.time;
                journeyLength = Vector3.Distance(position0.position, position1.position);
                rotationLength = transform.rotation;
            }
            
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(position0.position, position1.position, fracJourney);
            transform.rotation = Quaternion.Lerp(rotationLength, Quaternion.identity, fracJourney);

            if (transform.position == position1.position && player.GetComponent<Rigidbody>().velocity.magnitude <= 0.1f)
            {
                speed = 30;
                state = 2;
            }
        }
        #endregion

        #region cinematic2
        if (state == 2)
        {
            if(!transition1)
            {
                transition1 = true;
                startTime = Time.time;
                journeyLength = Vector3.Distance(position1.position, position2.position);
                rotationLength = transform.rotation;
            }

            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(position1.position, position2.position, fracJourney);
            transform.rotation = Quaternion.Lerp(rotationLength, Quaternion.Euler(0, -30, 0), fracJourney);

            if(transform.position == position2.position)
            {
                position3 = new Vector3(player.transform.position.x, player.transform.position.y + 10, temp);
                StartCoroutine(transitionToState3());
            }
        }
        #endregion

        #region cinematic3
        if (state == 3)
        {
            if(!transition2)
            {
                transition2 = true;
                startTime = Time.time;
                journeyLength = Vector3.Distance(position2.position, position3);
                rotationLength = transform.rotation;
            }

            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(position2.position, position3, fracJourney);
            transform.rotation = Quaternion.Lerp(rotationLength, Quaternion.Euler(26.565f, 0, 0), fracJourney);

            if (transform.position == position3)
            {
                state = 5;
            }
        }
        #endregion

        #region Default
        if (state ==4)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 10, temp);//delete this later
            transform.LookAt(player.transform);
        }
        #endregion

        #region cinematic4
        if (state == 5 && !once)
        {
            once = true;
            Invoke("three", 0);
            Invoke("two", 1);
            Invoke("one", 2);
            Invoke("go", 3);
        }
        #endregion
    }


    IEnumerator transitionToState3()
    {
        yield return new WaitForSeconds(1.5f);
        state = 3;
    }

    void three()
    {
        audEN.clip = threeaud;
        audEN.Play();
    }

    void two()
    {
        audEN.clip = twoaud;
        audEN.Play();
    }

    void one()
    {
        audEN.clip = oneaud;
        audEN.Play();
    }

    void go()
    {
        audEN.clip = goaud;
        audEN.Play();
        audBG.clip = popaud;
        audBG.Play();
        player.GetComponent<PlayerController>().AcceptsControls = true;
        state = 4;
    }

}
