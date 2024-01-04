using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody rb;
    void Update()
    {
        if (UIControl.Is_GameStart)
        {
            transform.position += Camera.main.transform.forward * 3 * Time.deltaTime;
        }
        else
        {
            rb.velocity = new Vector3(0,0,0);
            transform.position = new Vector3(0,3.6f,0);
            HealthHUDController.health = 50;
            EnergyHUDController.Energy = 60;
            GameObject UI = GameObject.Find("UI");
            UI.SetActive(true);
        }
    }
}
