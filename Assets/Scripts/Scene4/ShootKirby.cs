using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootKirby : MonoBehaviour {

    public GameObject player;
    public GameObject marker;
    public GameObject landSpot;
    GameObject inPlayer;
    Rigidbody rb;
    public int thrust;

    bool once = false;

    float A;
    float B;
    float C;

	// Use this for initialization
	void Start ()
    {
        A = 0.5f * Physics.gravity.y;
    }
	
	// Update is called once per frame
	
     void Update ()
    {
        /*float temp = thrust * Mathf.Cos(Mathf.Deg2Rad * this.gameObject.transform.rotation.eulerAngles.z);
        float temptime = (2 * thrust * Mathf.Sin(Mathf.Deg2Rad * this.gameObject.transform.rotation.eulerAngles.z)) / -Physics.gravity.y;
        landSpot.transform.position = new Vector3((marker.transform.position.x) + (temp * temptime), 15, 0);*/
        B = thrust * Mathf.Sin(Mathf.Deg2Rad * this.gameObject.transform.rotation.eulerAngles.z);
        C = marker.transform.position.y - landSpot.transform.position.y;
        float quadanswer = (-B - Mathf.Sqrt((B * B) - 4 * A * C)) / (2 * A);
        float temp = thrust * Mathf.Cos(Mathf.Deg2Rad * this.gameObject.transform.rotation.eulerAngles.z);
        landSpot.transform.position = new Vector3((marker.transform.position.x) + (temp * quadanswer), 15, 0);

        if (Input.GetKeyDown(KeyCode.Space) && !once)
        {
            once = true;
            inPlayer = Instantiate(player, marker.transform.position, Quaternion.identity);
            rb = inPlayer.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.velocity = new Vector3(thrust * Mathf.Cos(Mathf.Deg2Rad * this.gameObject.transform.rotation.eulerAngles.z),
                                      thrust * Mathf.Sin(Mathf.Deg2Rad * this.gameObject.transform.rotation.eulerAngles.z),
                                      0);
        }
	}
     
}
