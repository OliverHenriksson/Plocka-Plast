using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Text : MonoBehaviour
{
    public TMP_Text plastText;
    public TMP_Text money;

    public TMP_Text levelS;
    public TMP_Text levelB;
    public TMP_Text levelH;

    public TMP_Text p1;
    public TMP_Text p2;
    public TMP_Text p3;

    int price1 = 100;
    int price2 = 50;
    int price3 = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�ndrar all text som finns p� UIn -Morgan
        plastText.text = PlayerScript.plast + " / " + PlayerScript.bag;

        levelS.text = "Level " + PlayerScript.Slevel;
        levelB.text = "Level " + PlayerScript.Blevel;
        levelH.text = "Level " + PlayerScript.Hlevel;

        p1.text = "" + price1;
        p2.text = "" + price2;
        p3.text = "" + price3;

        money.text = PlayerScript.money + " Money";
    }

    public void BuyS() //Vad som ska h�nda n�r man k�per speed -Oliver
    {
        if (PlayerScript.money >= price1)
        {
            PlayerScript.moveSpeed += 2;
            PlayerScript.money -= price1;
            PlayerScript.Slevel++;
            price1 += 100;
        }
    }

    public void BuyB() //Vad som ska h�nda n�r man k�per bag -Oliver
    {
        if(PlayerScript.money >= price2)
        {
            PlayerScript.bag += 5;
            PlayerScript.money -= price2;
            PlayerScript.Blevel++;
            price2 += 100;
        }
    }

    public void BuyH() //Vad som ska h�nda n�r man k�per pickup speed -Oliver
    {
        if(PlayerScript.money >= price3)
        {
            TrashScript.pickupTime -= 0.1f;
            PlayerScript.money -= price3;
            PlayerScript.Hlevel++;
            price3 += 100;
        }
    }
}
