using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPlatform2 : MonoBehaviour {

    [SerializeField] AudioSource aud;
    [SerializeField] AudioClip win;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            aud.clip = win;
            aud.Play();
            other.gameObject.GetComponent<PlayerController>().AcceptsControls = false;
            Invoke("StartScene3", 4);
        }
    }

    void StartScene3()
    {
        SceneManager.LoadScene("Scene3");
    }
}
