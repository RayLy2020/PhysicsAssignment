using UnityEngine;
using System.Collections;

public class DeathBarrier : MonoBehaviour {

    public GameObject startPosition;

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
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.transform.position = startPosition.transform.position;
		}
	}
}
