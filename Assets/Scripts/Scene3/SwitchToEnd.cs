using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SwitchToEnd : MonoBehaviour {

    [SerializeField] AudioSource aud;
    [SerializeField] AudioClip win;
    bool once = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && !once)
        {
            once = true;
            aud.clip = win;
            aud.Play();
            other.gameObject.GetComponent<PlayerController>().AcceptsControls = false;
            Invoke("SwitchToScene4", 4);
        }
    }

    void SwitchToScene4()
    {
        SceneManager.LoadScene("Scene4");
    }
}
