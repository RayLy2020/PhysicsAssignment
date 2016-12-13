using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCannon1 : MonoBehaviour {

    [SerializeField] GameObject player;
    [SerializeField] GameObject smoke;
    [SerializeField] GameObject ammoBox;
    [SerializeField] GameObject endObj;
    [SerializeField] AudioSource audMusic;
    [SerializeField] AudioClip victory;
    [SerializeField] AudioClip Wah;
    [SerializeField] AudioSource audEnv;
    [SerializeField] AudioClip boom;
    [SerializeField] AudioSource audKirby;
    [SerializeField] AudioClip zoom;

    [SerializeField] int state = 0;


    Rigidbody rb;
    bool state0Fire = false;
    bool state2Fire = false;
    bool state1Fire = false;
    bool state3Fire = false;

    [SerializeField] float speed = 50;

    float startTime;
    float journeyLength;
    float distCovered;
    float fracJourney;

    Vector3 startPos;

	// Use this for initialization
	void Start ()
    {
        rb = player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        #region cinematic1
        if (state==1 && !state1Fire)
        {
            state1Fire = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.AddForce(0, 15, 0, ForceMode.Impulse);
            player.GetComponent<Rigidbody>().velocity = ((ammoBox.transform.position - player.gameObject.transform.position) / 3.1f);
            StartCoroutine("startState2");
            StartCoroutine("startState3");
        }
        #endregion

        #region cinematic2
        if (state == 2 && !state2Fire)
        {
            startTime = Time.time;
            startPos = player.gameObject.transform.position;
            journeyLength = Vector3.Distance(startPos, endObj.transform.position);
        }
        if(state ==2)
        { 
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            player.transform.position = Vector3.Lerp(startPos, endObj.transform.position, fracJourney);
        }
        #endregion

        #region cinematic3
        if (state==3 && !state3Fire)
        {
            state3Fire = true;
            player.transform.position = endObj.transform.position;
            rb.AddForce(30, 30, 0, ForceMode.Impulse);
            audEnv.clip = boom;
            audEnv.Play();
            audMusic.clip = Wah;
            audMusic.loop = false;
            audMusic.Play();
            audKirby.clip = zoom;
            audKirby.Play();
            smoke.SetActive(true);
            Invoke("StartScene2", 4);
        }
	}
    #endregion

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player" && !state0Fire)
        {
            state0Fire = true;
            other.gameObject.GetComponent<PlayerController>().AcceptsControls = false;
            audMusic.clip = victory;
            audMusic.Play();
            state = 1;
        }
    }

    IEnumerator startState2()
    {
        yield return new WaitForSeconds(3.1f);
        state = 2;
    }

    IEnumerator startState3()
    {
        
        yield return new WaitForSeconds(3.5f);
        state = 3;
    }

    void StartScene2()
    {
        SceneManager.LoadScene("Scene2");
    }
}
