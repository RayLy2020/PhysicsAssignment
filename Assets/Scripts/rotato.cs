using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotato : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow) && gameObject.transform.rotation.eulerAngles.z <= 50 && gameObject.transform.rotation.eulerAngles.z >= 0)
        {
            transform.Rotate(new Vector3(0, 0, 1), Space.World);
        }

        if (gameObject.transform.rotation.eulerAngles.z > 1 && gameObject.transform.rotation.eulerAngles.z <= 51)
        {
            Debug.Log("hi");
            Debug.Log(gameObject.transform.rotation.eulerAngles.z);
            if (Input.GetKey(KeyCode.DownArrow))
            {
             
            transform.Rotate(new Vector3(0, 0, -1), Space.World);
            }
        }
	}
}
