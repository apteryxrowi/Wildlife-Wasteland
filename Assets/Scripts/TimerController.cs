using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public float minutes = 20;
    private protected float Timer;
    private Text myText;
    // Update is called once per frame
    private void Start()
    {
        Timer = minutes * 60;
        myText = GetComponent<Text>();
        myText.text = minutes + " : " + "00";
    }
    void Update()
    {
        if (UIControl.Is_GameStart)
        {
            Timer -= Time.deltaTime;
            float x = Mathf.FloorToInt(Timer / 60);
            float y = Mathf.FloorToInt(((Timer / 60) % 1) * 60);
            if (y < 10)
            {
                myText.text = x + " : 0" + y;
            }
            else
            {
                myText.text = x + " : " + y;
            }
            if (Timer <= 0)
            {
                HealthHUDController.health = 0;
            }
        }
        else
        {
            Timer = minutes * 60;
        }
    }
}
