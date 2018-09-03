using UnityEngine;

public class PfupfController : BeingController
{       
    private void Awake()
    {
        blinkEyeTime = getNextBlinkEyeTime();
    }

    private void Update()
    {
        Blink();
    }
}

