using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor.UI;
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
            if (Timer >= WaitDuration && FoodHUDController.Food >= 50)
            {
                Timer = 0f;
                health += 10;
                FoodHUDController.FoodChange(-5);
            }
        }
    }
}
