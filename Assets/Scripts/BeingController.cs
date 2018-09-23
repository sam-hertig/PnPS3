using UnityEngine;

public class BeingController : MonoBehaviour {

    public GameObject[] eyeballs;
    public BeingController partnerController;
    public GameManager gameManager;

    public int numberOfBlankets;
    public int maxNumberOfBlankets; //[HideInInspector] 
    

    private float blinkEyeTime;
    private bool blinking = false;


    protected virtual void Awake ()
    {
        blinkEyeTime = getNextBlinkEyeTime();
        numberOfBlankets = 0;
    }


    protected virtual void Update ()
    {
        Blink();
    }


    private void Blink ()
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


    private float getNextBlinkEyeTime ()
    {
        return Time.time + Random.Range(2f, 8f);
    }


    protected virtual void OnTriggerEnter (Collider other) 
    {
        if (other.gameObject.CompareTag ("Blanket") && numberOfBlankets < maxNumberOfBlankets)
        {
            other.gameObject.transform.SetParent(transform);
            other.gameObject.transform.localPosition = new Vector3(0, 0, 0);
            numberOfBlankets++;
        }
    }
}
