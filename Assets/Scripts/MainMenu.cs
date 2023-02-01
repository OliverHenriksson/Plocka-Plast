using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour 
{
    //Gör så man kan starta och avsluta spelet från menyn -Melvin
   public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Man byter till startscenen -Melvin
    }

    public void QuitGame()
    {
        Application.Quit(); //Spelet avslutas -Melvin
    }
}
