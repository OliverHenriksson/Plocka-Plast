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
    public static int bag = 10;
    public static bool stop;
    public static int Slevel = 1;
    public static int Blevel = 1;
    public static int Hlevel = 1;

    public Image circ;
    public GameObject shop;

    public float t2;
    bool thing;

    public static int money;

    // Start is called before the first frame update
    void Start()
    {
        t2 = 0;
        //bag = 10;
        shop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            money += 100;
        }

        if(thing == true) //Startar  -Oliver
        {
            t2 += Time.deltaTime;
        }

        if(t2 >= TrashScript.pickupTime) //G�r s� att cirkeln f�rsvinner n�r du plockat upp n�got -Oliver
        {
            t2 = 0;
            thing = false;
        }

        circ.fillAmount = t2 / 2;  //Fyller cirkeln -Oliver

        if(plast >= bag)  //G�r s� att om man har en full bag s� kan man inte plocka upp mer -Oliver
        {
            TrashScript.no = true;
        }
        else
        {
            TrashScript.no = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))  //St�nger shopen -Oliver
        {
            shop.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if(stop != true)
        {
            //Movement -Ian
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
        if (col.gameObject.tag == "Plast" && Input.GetKeyDown(KeyCode.Space) && TrashScript.no == false) //G�r s� att cirkeln fylls n�r du plockar upp n�got -Oliver
        {
            thing = true;
        }

        if (col.gameObject.tag == "Shop")  //�ppnar shopen -Oliver
        {
            shop.SetActive(true);
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.tag == "Sell")  //G�r s� att man kan s�lja sin plast -Oliver
        {
            for (int i = 0; i < plast; i++) //Kollar hur mycket plast du har och ger dig pengar f�r dem -Oliver
            {
                money++;
                plast--;
            }
        }
    }
}
