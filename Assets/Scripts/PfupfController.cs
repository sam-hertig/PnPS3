using UnityEngine;

public class PfupfController : BeingController
{
    protected override void Start()
    {
        base.Start();
        GameManager gameManager = FindObjectOfType<GameManager>();
        MaxNumberOfBlankets = gameManager.NumberOfBlankets;
    }

    protected override void Update()
    {
        base.Update();
        if (NumberOfBlankets == MaxNumberOfBlankets) {
            GameManager.GameWon();
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.CompareTag("Blanket") && NumberOfBlankets < MaxNumberOfBlankets && PartnerController != null)
        {
            AudioController.PlayAudio(true);
            other.gameObject.tag = "BlanketInPlace";
            PartnerController.NumberOfBlankets--;
        }
    }
}

