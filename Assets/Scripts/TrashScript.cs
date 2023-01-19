using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    //All kod här är av mig -Oliver

    bool yes;

    public float t;
    public static float pickupTime = 2;
    bool timestart;
    public static bool no;
    public bool no2;

    public GameObject parent;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;  //Gör påsen osynlig
    }

    // Update is called once per frame
    void Update()
    {
        if(parent.transform.childCount == 0) //Om det inte finns kloner så spawnar den fler
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(gameObject);
            }
        }

        no2 = no;
        if(timestart == true) //Startar tiden
        {
            PlayerScript.stop = true;
            t += Time.deltaTime;
        }
        else
        {
            t = 0;
        }

        if (t >= pickupTime)  //När tiden är samma som tiden det ska ta att plocka upp något så plockar den upp plasten
        {
            PlayerScript.stop = false;
            timestart = false;
            PlayerScript.plast++;
            Destroy(gameObject);
        }

        if (gameObject.name != "Plast")  //Allt som ska hända när det är en klon
        {
            sr.enabled = true;  //Gör så att man kan se den

            gameObject.transform.SetParent(parent.transform);

            gameObject.tag = "Plast";  //Ger tagen plast

            if(yes == false)  //Gör så att påsen spawnar på en random plats
            {
                transform.position = new Vector2(Random.Range(-8.5f, 8.5f), Random.Range(-4.5f, 4.5f));
                yes = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(gameObject.name != "Plast")
        {
            if (col.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.Space) && no == false) //Gör så att man kan plocka upp plasten
            {
                timestart = true;
            }
        }
    }
}
