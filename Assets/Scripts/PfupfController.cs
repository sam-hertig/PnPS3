using UnityEngine;

public class PfupfController : BeingController
{
    protected override void Update ()
    {
        base.Update();
        if (numberOfBlankets == maxNumberOfBlankets) {
            gameManager.gameWon();
        }
    }


    protected override void OnTriggerEnter (Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.CompareTag("Blanket") && numberOfBlankets < maxNumberOfBlankets && partnerController!=null)
        {
        	other.gameObject.tag = "BlanketInPlace";
            partnerController.numberOfBlankets--;
        }
    }
}

