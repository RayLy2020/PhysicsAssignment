using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotato : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))&& gameObject.transform.rotation.eulerAngles.z <= 60 && gameObject.transform.rotation.eulerAngles.z >= 14)
        {
            transform.Rotate(new Vector3(0, 0, 0.5f), Space.World);
        }

        if (gameObject.transform.rotation.eulerAngles.z > 15 && gameObject.transform.rotation.eulerAngles.z <= 61)
        {
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
            transform.Rotate(new Vector3(0, 0, -0.5f), Space.World);
            }
        }
	}
}
