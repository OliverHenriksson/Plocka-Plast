using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    bool yes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(gameObject);
            }
        }

        if (gameObject.name != "Plast")
        {
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
}
