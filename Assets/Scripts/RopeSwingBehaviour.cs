using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSwingBehaviour : MonoBehaviour {

    [SerializeField] float swingDelay;
    int state = 0; //0 stationary left, 1 moving right, 2 stationairy right, 3 moving left

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		switch(state)
        {
            case 0:

                break;
        }
	}
}
