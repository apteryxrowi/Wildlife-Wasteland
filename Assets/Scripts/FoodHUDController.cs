using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

public class FoodHUDController : MonoBehaviour
{
    public static int Food = 50;
    public float WaitDuration;
    protected float Timer;
    [SerializeField] private TextMeshProUGUI myText;
    // Update is called once per frame
    public static void FoodChange(int amount)
    {
        Food = Food + amount;
    }
    void Update()
    {
        UIControl.Is_GameStart = true;
        if (UIControl.Is_GameStart && Food >= 0 && Food <= 50)
        {
            Timer += Time.deltaTime;
            myText.text = "";
            for (int i = 0; i < Food / 10; i++)
            {
                myText.text += "\u26a1";
            }
            //myText.text = Food.ToString();
            if (Timer >= WaitDuration)
            {
                Timer = 0f;
                Food = Food - 10;
            }
        }
    }
}
