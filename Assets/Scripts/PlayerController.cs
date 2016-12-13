using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// NOTE TO SELF
    /// I DISABLED TO INTRO, PUT IT BACK ON
    /// kirby needs gravity, and shouldnt be able to move at the start
    /// move start location
    /// </summary>
	//Intro

    //Setup
    Rigidbody rb;
    [SerializeField] AudioSource aud;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip landSound;
    [SerializeField] AudioClip falcon;
    [SerializeField] AudioClip punch;
    [SerializeField] AudioClip taunt;


	//Controls
	public bool AcceptsControls = true; // change to false;
    public float speed;
    [SerializeField] float jumpForce;
    public int jumpCounter = 0;
    float speedBeforeJump;
    int maxJumps = 5;
    bool onGround = true;
    public bool boosted = false;

    
	void Start () 
	{
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 10000.0f;
	}
	
	void Update () 
	{
        if(AcceptsControls)
        {
            #region Speed Limiter
            if (rb.velocity.magnitude > speed/2 && !boosted)
            {
                float temp = rb.velocity.y;
                rb.velocity = rb.velocity.normalized * (speed / 2);
                rb.velocity = new Vector3(rb.velocity.x, temp, rb.velocity.z);
            }
            #endregion

            /*if(rb.velocity.x > speed/2)
            {
                rb.velocity = new Vector3(speed/2, rb.velocity.y, rb.velocity.z);
            }
            if(rb.velocity.z > speed/2)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed / 2);
            }*/

            #region Ground Control
            rb.angularVelocity = Vector3.zero;
            if (Input.GetKey(KeyCode.A))
            {
                rb.angularVelocity = new Vector3(rb.angularVelocity.x, rb.angularVelocity.y, speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.angularVelocity = new Vector3(rb.angularVelocity.x, rb.angularVelocity.y, -speed);
            }
            if (Input.GetKey(KeyCode.W))
            {
                rb.angularVelocity = new Vector3(speed, rb.angularVelocity.y, rb.angularVelocity.z);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.angularVelocity = new Vector3(-speed, rb.angularVelocity.y, rb.angularVelocity.z);
            }
            #endregion

            #region Air Controls
            if (!onGround)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    if(speedBeforeJump < 5)
                    {
                        rb.velocity = new Vector3(-5, rb.velocity.y, rb.velocity.z);
                    }
                    else
                    {
                        rb.velocity = new Vector3(-speedBeforeJump, rb.velocity.y, rb.velocity.z);
                    }
                }
                if (Input.GetKey(KeyCode.D))
                {
                    if (speedBeforeJump < 5)
                    {
                        rb.velocity = new Vector3(5, rb.velocity.y, rb.velocity.z);
                    }
                    else
                    {
                        rb.velocity = new Vector3(speedBeforeJump, rb.velocity.y, rb.velocity.z);
                    }
                }
                if (Input.GetKey(KeyCode.W))
                {
                    if(speedBeforeJump < 5)
                    {
                        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 5);
                    }
                    else
                    {
                        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speedBeforeJump);
                    }
                }
                if (Input.GetKey(KeyCode.S))
                {
                    if (speedBeforeJump < 5)
                    {
                        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -5);
                    }
                    else
                    {
                        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -speedBeforeJump);
                    }
                 }
            }
            #endregion

            #region Jump Controls
            if (Input.GetKeyDown(KeyCode.Space) && jumpCounter < maxJumps)
            {
                rb.useGravity = true;       /////////////// TAKE THIS OUT LATER
                //this.gameObject.transform.SetParent(null);
                aud.clip = jumpSound;
                aud.Play();
                if (onGround)
                {
                    speedBeforeJump = rb.velocity.magnitude;
                } 
                onGround = false;
                rb.velocity = Vector3.zero;
                if (Input.GetKey (KeyCode.A))
                {
                    rb.AddForce(Vector3.left * jumpForce, ForceMode.Impulse);
                    rb.velocity = Vector3.left * jumpForce;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    rb.AddForce(Vector3.right * jumpForce, ForceMode.Impulse);
                    rb.velocity = Vector3.right * jumpForce;
                }
                if (Input.GetKey(KeyCode.W))
                {
                    rb.AddForce(Vector3.forward * jumpForce, ForceMode.Impulse);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    rb.AddForce(Vector3.back * jumpForce, ForceMode.Impulse);
                }
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jumpCounter++;
            }
            #endregion

            #region Silly Controls
            if(Input.GetKeyDown(KeyCode.Z))
            {
                aud.clip = taunt;
                aud.Play();
            }
            if(Input.GetKeyDown(KeyCode.X))
            {
                aud.clip = falcon;
                aud.Play();
                StartCoroutine("punchu");
            }
            #endregion
        }
	}

    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "Floor":
                {
                    if(jumpCounter != 0)
                    {
                        aud.clip = landSound;
                        aud.Play();
                    }
                    jumpCounter = 0;
                    onGround = true;
                    boosted = false;
                    AcceptsControls = true;
                    break;
                }
        }
    }

    IEnumerator punchu()
    {
        yield return new WaitForSeconds(1);
        if(aud.clip == falcon)
        {
            aud.clip = punch;
            aud.Play();
        }
    }
}
