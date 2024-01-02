using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine.UI;
using UnityEngine;

public class FoodHUDController : MonoBehaviour
{
    public static int Food = 60;
    public float WaitDuration;
    protected float Timer;
    public Text myText;
    // Update is called once per frame
    public static void FoodChange(int amount)
    {
        Food = Food + amount;
    }
    void Update()
    {
        UIControl.Is_GameStart = true;
        // delete after done ^^^^
        if (UIControl.Is_GameStart && Food > 0 && Food <= 60)
        {
            Timer += Time.deltaTime;
            myText.text = "";
            for (int i = 0; i < Food / 10; i++)
            {
                myText.text += "S";
            }
            //myText.text = Food.ToString();
            if (Timer >= WaitDuration)
            {
                Timer = 0f;
                Food -= 10;
            }
        }
    }
}
