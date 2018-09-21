using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeingController : MonoBehaviour {

    public GameObject[] eyeballs;
    [HideInInspector] public int maxNumberOfBlankets;
    [HideInInspector] public int numberOfBlankets;

    private float blinkEyeTime;
    private bool blinking = false;


    public virtual void Awake()
    {
        blinkEyeTime = getNextBlinkEyeTime();
        numberOfBlankets = 0;
    }


    public virtual void Update()
    {
        Blink();
    }


    private void Blink()
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


    private float getNextBlinkEyeTime()
    {
        return Time.time + Random.Range(2f, 8f);
    }


    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ( "Blanket") && numberOfBlankets < maxNumberOfBlankets)
        {
            other.Transform.setParent(transform);
            numberOfBlankets++;
        }
    }


}
