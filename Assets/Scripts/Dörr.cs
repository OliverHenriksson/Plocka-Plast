using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Dörr : MonoBehaviour
{
    //Den här koden gör så att man kan gå ut och in i affären -Melvin
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && gameObject.name == "In") //Om objektet som heter"Player" kolliderar med objektet som heter "In" så ändras scen +1 så man kommer in
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (collision.gameObject.name == "Player" && gameObject.name == "Ut") //Om objektet som heter"Player" kolliderar med objektet som heter "Ut" så ändras scen -1 så man kommer ut
        {
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
    }
}
