using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;

    public static int plast;
    public static bool stop;

    public Image circ;
    float t2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        circ.fillAmount = t2 / 2;
    }

    private void FixedUpdate()
    {
        if(stop != true)
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");

            moveInput.Normalize();

            rb2d.velocity = moveInput * moveSpeed;
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
        
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Plast")
        {
            t2 = col.gameObject.GetComponent<TrashScript>().t;
        }
    }
}
