using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public static float moveSpeed = 7;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;

    public static int plast;
    public static int bag;
    public static bool stop;
    public static int Slevel = 1;
    public static int Blevel = 1;
    public static int Hlevel = 1;

    public Image circ;
    public GameObject shop;

    public float t2;
    bool thing;

    public static int money = 1000;

    // Start is called before the first frame update
    void Start()
    {
        t2 = 0;
        bag = 10;
        shop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(thing == true)
        {
            t2 += Time.deltaTime;
        }

        if(t2 >= 2)
        {
            t2 = 0;
            thing = false;
        }

        circ.fillAmount = t2 / 2;

        if(plast == bag)
        {
            TrashScript.no = true;
        }
        else
        {
            TrashScript.no = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            shop.SetActive(false);
        }
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
        if (col.gameObject.tag == "Plast" && Input.GetKeyDown(KeyCode.Space) && TrashScript.no == false)
        {
            thing = true;
        }

        if (col.gameObject.tag == "Shop")
        {
            shop.SetActive(true);
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.tag == "Sell")
        {
            for (int i = 0; i < plast; i++)
            {
                money++;
                plast--;
            }
        }
    }
}
