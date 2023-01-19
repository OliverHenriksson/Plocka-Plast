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

    public static int price1;
    public static int price2;
    public static int price3;

    // Start is called before the first frame update
    void Start()
    {
        price1 = 100;
        price2 = 50;
        price3 = 100;
    }

    // Update is called once per frame
    void Update()
    {
        //Ändrar all text som finns på UIn -Morgan
        plastText.text = PlayerScript.plast + " / " + PlayerScript.bag;

        levelS.text = "Level " + PlayerScript.Slevel;
        levelB.text = "Level " + PlayerScript.Blevel;
        levelH.text = "Level " + PlayerScript.Hlevel;

        p1.text = "" + price1;
        p2.text = "" + price2;
        p3.text = "" + price3;

        money.text = PlayerScript.money + " Money";
    }

    public void BuyS() //Vad som ska hända när man köper speed -Oliver
    {
        if (PlayerScript.money >= price1)
        {
            PlayerScript.moveSpeed += 2;
            PlayerScript.money -= price1;
            PlayerScript.Slevel++;
            price1 += 100;
        }
    }

    public void BuyB() //Vad som ska hända när man köper bag -Oliver
    {
        if(PlayerScript.money >= price2)
        {
            PlayerScript.bag += 5;
            PlayerScript.money -= price2;
            PlayerScript.Blevel++;
            price2 += 100;
        }
    }

    public void BuyH() //Vad som ska hända när man köper pickup speed -Oliver
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
