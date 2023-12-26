using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

public class HealthHUDController : MonoBehaviour
{
    public static int health = 5;
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
        UIControl.Is_GameStart = true;
        if (UIControl.Is_GameStart && health >= 0)
        {
            Timer += Time.deltaTime;
            myText.text = health.ToString();
            if (Timer >= WaitDuration)
            {
                Timer = 0f;
                health = health - 1;
            }
        }
    }
}
