using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashScript : MonoBehaviour
{
    bool yes;

    public float t;
    bool timestart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timestart == true)
        {
            PlayerScript.stop = true;
            t += Time.deltaTime;
        }
        else
        {
            t = 0;
        }

        if (t >= 2)
        {
            PlayerScript.stop = false;
            timestart = false;
            PlayerScript.plast++;
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(gameObject);
            }
        }

        if (gameObject.name != "Plast")
        {
            gameObject.tag = "Plast";

            if(yes == false)
            {
                transform.position = new Vector2(Random.Range(-8.5f, 8.5f), Random.Range(-4.5f, 4.5f));
                yes = true;
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(gameObject.name != "Plast")
        {
            if (col.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.Space))
            {
                timestart = true;
            }
        }
    }
}
