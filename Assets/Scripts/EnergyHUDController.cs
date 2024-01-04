using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine.UI;
using UnityEngine;

public class EnergyHUDController : MonoBehaviour
{
    public static int Energy = 60;
    public float WaitDuration;
    protected float Timer;
    public Text myText;
    // Update is called once per frame
    public static void EnergyChange(int amount)
    {
        Energy = Energy + amount;
    }
    void Update()
    {
        if (UIControl.Is_GameStart && Energy >= 0 && Energy <= 60)
        {
            Timer += Time.deltaTime;
            myText.text = "";
            for (int i = 0; i < Energy / 10; i++)
            {
                myText.text += "S";
            }
            //myText.text = Energy.ToString();
            if (Timer >= WaitDuration)
            {
                Timer = 0f;
                Energy -= 10;
            }
        }
    }
}
