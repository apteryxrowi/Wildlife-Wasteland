using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

public class HealthHUDController : MonoBehaviour
{
    public static int health = 50;
    public float WaitDuration;
    protected float Timer;
    [SerializeField] private TextMeshProUGUI myText;
    // Update is called once per frame
    public static void EatFood(int amount)
    {
        health = health + amount;
    }
    void Update()
    {
        if (UIControl.Is_GameStart && health >= 0 && health <= 50)
        {
            Timer += Time.deltaTime;
            myText.text = "";
            for (int i = 0; i < health/10; i++)
            {
                myText.text += "\u2665";
            }
            //myText.text = health.ToString();
            if (Timer >= WaitDuration)
            {
                Timer = 0f;
                health = health - 10;
            }
        }
    }
}
