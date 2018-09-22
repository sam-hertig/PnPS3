using UnityEngine;

public class PfupfController : BeingController
{
    protected override void Awake()
    {
        base.Awake();
        maxNumberOfBlankets = 10;
    }

    protected override void Update()
    {
        base.Update();
        if (numberOfBlankets == maxNumberOfBlankets) {
            //gameWon();
            print("Well done!");
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.CompareTag("Blanket") && numberOfBlankets < maxNumberOfBlankets && partner!=null)
        {
            //partner.numberOfBlankets--;
        }
    }
}

