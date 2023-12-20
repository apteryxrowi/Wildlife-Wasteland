using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody rb;
    float x;
    float y;
    float z;

    // Wait until a message is received than movement is unlocked
    void ChangeRotation(Quaternion Rotation)
    {
        x = Rotation.eulerAngles[0];
    }
    void ChangePosition(Vector3 Position)
    {
        Debug.Log(Position);
    }
    void Update()
    {
        if (UIControl.Is_GameStart)
        {
            transform.position += Camera.main.transform.forward * 3 * Time.deltaTime;
        }
        else
        {
            rb.velocity = new Vector3(0,0,0);
        }
    }
}
