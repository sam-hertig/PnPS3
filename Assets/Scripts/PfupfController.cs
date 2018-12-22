using UnityEngine;

public class PfupfController : BeingController
{
    private GameManager gameManager;

    protected override void Start()
    {
        base.Start();
        gameManager = FindObjectOfType<GameManager>();
        MaxNumberOfBlankets = gameManager.NumberOfBlankets;
    }

    private void Update()
    {
        Blink();
        if (NumberOfBlankets == MaxNumberOfBlankets) {
            gameManager.GameWon();
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

