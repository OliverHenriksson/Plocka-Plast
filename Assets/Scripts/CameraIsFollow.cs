using UnityEngine;
using System.Collections;

public class CameraIsFollow : MonoBehaviour
{

    public GameObject player;        


    private Vector3 offset;            

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset; //Kameran f�ljer spelaren -Melvin
    }
}