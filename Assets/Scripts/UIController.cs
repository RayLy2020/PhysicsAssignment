using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text instructions;
    public Image logo;
    public GameObject player;
    Color m_colour;
    [SerializeField] AudioSource aud;
    [SerializeField] AudioClip boom;

    public GameObject smoke;
    bool Started = false;
    int timey = 0;
    [SerializeField] bool once = false;
    float m_alpha = 1;
    //Maths
    float AlphaValue = 1.0f;

    // Use this for initialization
    void Start()
    {
        m_colour = Color.yellow;
        m_colour.g = 0.9f;
        InvokeRepeating("Increment", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !Started)
        {
            Started = true;
            InvokeRepeating("Decrement", 0, 0.01f);
        }
        if (once)
        {
            m_alpha -= 0.01f;
            foreach (Renderer ren in smoke.GetComponentsInChildren<Renderer>())
            {
                ren.material.color = new Color(0, 0, 0, m_alpha);
            }
        }
        if(m_alpha <= 0)
        {
            this.enabled = false;
        }
    }

    void Increment()
    {
        timey++;
        if (timey % 2 == 0)
        {
            instructions.color = Color.black;
        }
        else
        {
            instructions.color = m_colour;
        }
    }
    
    void Decrement()
    {
        AlphaValue -= 0.005f;
        instructions.GetComponent<CanvasRenderer>().SetAlpha(AlphaValue);
        logo.GetComponent<CanvasRenderer>().SetAlpha(AlphaValue);

        if(AlphaValue <= 0)
        {
            AlphaValue = 1;
            CancelInvoke();
            Camera.main.GetComponent<CameraController>().state = 1;
            smoke.SetActive(true);
            aud.clip = boom;
            aud.Play();
            player.GetComponent<Rigidbody>().useGravity = true;
            once = true;
            player.GetComponent<Rigidbody>().velocity = new Vector3(10, 10, 0);
        }
    }
}
