using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    //All kod h�r �r av mig -Oliver

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
        sr.enabled = false;  //G�r p�sen osynlig
    }

    // Update is called once per frame
    void Update()
    {
        if(parent.transform.childCount == 0) //Om det inte finns kloner s� spawnar den fler
        {
            for (int i = 0; i < 30; i++)
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

        if (t >= pickupTime)  //N�r tiden �r samma som tiden det ska ta att plocka upp n�got s� plockar den upp plasten
        {
            PlayerScript.stop = false;
            timestart = false;
            PlayerScript.plast++;
            Destroy(gameObject);
        }

        if (gameObject.name != "Plast")  //Allt som ska h�nda n�r det �r en klon
        {
            sr.enabled = true;  //G�r s� att man kan se den

            gameObject.transform.SetParent(parent.transform);

            gameObject.tag = "Plast";  //Ger tagen plast

            if(yes == false)  //G�r s� att p�sen spawnar p� en random plats
            {
                transform.position = new Vector2(Random.Range(-9.1f, 70.5f), Random.Range(-26.2f, 38.9f));
                yes = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(gameObject.name != "Plast")
        {
            if (col.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.Space) && no == false) //G�r s� att man kan plocka upp plasten
            {
                timestart = true;
            }
        }
    }

    
}
