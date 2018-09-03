using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeingController : MonoBehaviour {

    public GameObject[] eyeballs;

    public float blinkEyeTime;
    public bool blinking = false;

    public void Blink()
    {
        if (Time.time > blinkEyeTime)
        {
            blinkEyeTime = getNextBlinkEyeTime();
            blinking = true;
        }
        if (blinking)
        {
            float currentAngle = Mathf.PingPong(500 * Time.time, 180f) + 90f;
            foreach (GameObject eyeball in eyeballs)
            {
                eyeball.transform.localEulerAngles = new Vector3(currentAngle, 0f, 0f);
            }
            if (currentAngle - 90f < 10)
            {
                blinking = false;
            }
        }
    }

    public float getNextBlinkEyeTime()
    {
        return Time.time + Random.Range(2f, 8f);
    }
}
