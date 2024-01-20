using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class HealthHUDController : MonoBehaviour
{
    public static int health = 50;
    public float WaitDuration;
    protected float Timer;
    [SerializeField] private Text myText;
    // Update is called once per frame
    public static void HealthChange(int amount)
    {
        health += amount;
    }
    void Update()
    {
        if (UIControl.Is_GameStart && health >= 0 && health <= 50)
        {
            Timer += Time.deltaTime;
            myText.text = "";
            for (int i = 0; i < health/10; i++)
            {
                myText.text += "O";
            }
            //myText.text = health.ToString();
            if (Timer >= WaitDuration && EnergyHUDController.Energy >= 50 && health < 50)
            {
                Timer = 0f;
                health += 10;
                if (health > 50)
                {
                    health = 50;
                }
                EnergyHUDController.EnergyChange(-5);
            }
            else if (Timer >= WaitDuration && (EnergyHUDController.Energy <= 0 || HydrationHUD.Hydration <= 0))
            {
                Timer = 0f;
                health -= 10;
            }
            else if (health <= 0)
            {
                UIControl.Is_GameStart = false;
            }
        }
    }
}
