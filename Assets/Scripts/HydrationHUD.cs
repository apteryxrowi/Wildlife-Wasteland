using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine.UI;
using UnityEngine;

public class HydrationHUD : MonoBehaviour
{
    public static int Hydration = 60;
    public float WaitDuration;
    protected float Timer;
    private Text myText;
    public static void HydrationChange(int amount)
    {
        Hydration = Hydration + amount;
    }
    void Start()
    {
        UIControl.Is_GameStart = true;
        myText = GetComponent<Text>();
    }
    void Update()
    {
        if (UIControl.Is_GameStart && Hydration >= 0 && Hydration <= 60)
        {
            Timer += Time.deltaTime;
            myText.text = "";
            for (int i = 0; i < Hydration / 10; i++)
            {
                myText.text += "I";
            }
            //myText.text = Hydration.ToString();
            if (Timer >= WaitDuration)
            {
                Timer = 0f;
                Hydration -= 10;
            }
        }
    }
}
