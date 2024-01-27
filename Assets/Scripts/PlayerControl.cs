using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody rb;
    private bool Is_Moving;
    void Update()
    {
        Move();
        if (UIControl.Is_GameStart)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Ended)
                {
                    Is_Moving = !Is_Moving;
                }
            }
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
            transform.position = new Vector3(0, 3.6f, 0);
            HealthHUDController.health = 50;
            EnergyHUDController.Energy = 60;
            HydrationHUD.Hydration = 60;
        }
    }
    void Move()
    {
        if (Is_Moving)
        {
            transform.position += Camera.main.transform.forward * 3 * Time.deltaTime;
        }
    }
}
