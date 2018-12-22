using UnityEngine;

public class BeingController : MonoBehaviour {

    public GameObject[] Eyeballs;
    public BeingController PartnerController;
    public GameManager GameManager;
    public int NumberOfBlankets;
    public AudioController AudioController;
    public int MaxNumberOfBlankets;

    private float _blinkEyeTime;
    private bool _blinking = false;

    protected virtual void Start()
    {
        _blinkEyeTime = GetNextBlinkEyeTime();
        NumberOfBlankets = 0;
    }

    protected void Blink()
    {
        if (Time.time > _blinkEyeTime)
        {
            _blinkEyeTime = GetNextBlinkEyeTime();
            _blinking = true;
        }
        if (_blinking)
        {
            float currentAngle = Mathf.PingPong(500 * Time.time, 180f) + 90f;
            foreach (GameObject eyeball in Eyeballs)
            {
                eyeball.transform.localEulerAngles = new Vector3(currentAngle, 0f, 0f);
            }
            if (currentAngle - 90f < 10)
            {
                _blinking = false;
            }
        }
    }

    private float GetNextBlinkEyeTime()
    {
        return Time.time + Random.Range(2f, 8f);
    }

    protected virtual void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Blanket") && NumberOfBlankets < MaxNumberOfBlankets)
        {
            other.gameObject.transform.SetParent(transform);
            other.gameObject.transform.localPosition = new Vector3(0, 0.55f + 0.08f * NumberOfBlankets, 0);
            NumberOfBlankets++;
        }
    }
}
