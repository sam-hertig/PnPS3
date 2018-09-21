using UnityEngine;

public class PfupfController : BeingController
{       
    private override void Awake()
    {
    	base.Awake();
     	maxNumberOfBlankets = 10;
    }

    private override void Update()
    {
     	base.Update();
        if (numberOfBlankets == maxNumberOfBlankets) {
        	gameWon();
        }
    }
}

