using UnityEngine;
using System.Collections;

public class DeathBarrier : MonoBehaviour {

    public GameObject startPosition;
    GameObject player;
    [SerializeField] AudioSource aud;
    [SerializeField] AudioClip deathsong;
    [SerializeField] AudioClip popstar;

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
            player = other.gameObject;
            Camera.main.GetComponent<CameraController>().state = 5;
            aud.clip = deathsong;
            aud.Play();
            StartCoroutine("respawn");
		}
	}

    IEnumerator respawn()
    {
        yield return new WaitForSeconds(6);
        Camera.main.GetComponent<CameraController>().state = 4;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.gameObject.transform.position = startPosition.transform.position;
        aud.clip = popstar;
        aud.Play();
    }
}
