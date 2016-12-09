using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterBehaviour : MonoBehaviour {

    public GameObject explosion;
    public GameObject smoke;
    public GameObject mine;
    public GameObject mineTop;
    GameObject createdObject;

    public Material ice;
    public Material red;

    int fadeOutTime = 5;
    int timey = 0;
    float m_alpha = 1;

    bool once = false;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("Increment", 0, 1);
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(once)
        {
            m_alpha -= 0.01f;
            foreach (Renderer ren in smoke.GetComponentsInChildren<Renderer>())
            {
                ren.material.color = new Color(0, 0, 0, m_alpha);
            } 
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !once)
        {
            once = true;
            createdObject = Instantiate(explosion, this.gameObject.transform.position, Quaternion.identity);
            createdObject.transform.localScale = new Vector3(5, 5, 5);
            smoke.SetActive(true);
            CancelInvoke();
            Destroy(mine);
            StartCoroutine("destroyAtEnd");
        }
    }
    void Increment()
    {
        timey++;
        if (timey % 2 == 0)
        {
            if(mineTop != null)
            {
                mineTop.GetComponent<Renderer>().material = ice;
            }
        }
        else
        {
            if(mineTop != null)
            {
                mineTop.GetComponent<Renderer>().material = red;
            }
        }
    }

    void Decrement()
    {
    }

    IEnumerator destroyAtEnd()
    {
        yield return new WaitForSeconds(fadeOutTime);
        Destroy(smoke);
        Destroy(this.gameObject);
    }
}
