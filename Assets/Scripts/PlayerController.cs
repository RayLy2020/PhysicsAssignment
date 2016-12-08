using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// NOTE TO SELF
    /// I DISABLED TO INTRO, PUT IT BACK ON
    /// </summary>
	//Intro

    //Setup
    Rigidbody rb;

	//Controls
	public bool AcceptsControls = true;
    bool Started = false;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;


	// Use this for initialization
	void Start () 
	{
        rb = this.gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        if(AcceptsControls)
        {
            //clamp speed
            if(Input.GetKey(KeyCode.A))
            {
                rb.AddForce(new Vector3(-speed, 0, 0));
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(new Vector3(speed, 0, 0));
            }
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(new Vector3(0, 0, speed));
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(new Vector3(0, 0, -speed));
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.useGravity = true;            
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                //disable ground controls when in air
                //space+d = jump right
            }

        }
	}
}
