using UnityEngine;

public class PookieController : BeingController
{       
    public float Speed = 5f;            
    public float TurnSpeed = 180f;
    public GameObject Feet;
    public float FootMinYPos = -0.52f;

    private Rigidbody _rigidbody;         
    private float _movementInputValue = 0f;    
    private float _turnInputValue = 0f;

    protected override void Start()
    {
        base.Start();
        _rigidbody = GetComponent<Rigidbody>();
        MaxNumberOfBlankets = 1;
    }

    private void Update()
    {
        Blink();
        _movementInputValue = Input.GetAxis ("Vertical");
        _turnInputValue = Input.GetAxis ("Horizontal");
        WiggleFeet();
    }


    private void FixedUpdate()
    {
        Move();
        Turn();
    }


    private void Move()
    {
        Vector3 movement = transform.forward * _movementInputValue * Speed * Time.deltaTime;
        _rigidbody.MovePosition(_rigidbody.position + movement);
        if (transform.position.y < -10) {
            GameManager.GameOver();
        }
    }

    private void Turn()
    {
        float turn = _turnInputValue * TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);
        _rigidbody.MoveRotation (_rigidbody.rotation * turnRotation);
    }

    private void WiggleFeet()
    {
        if (Mathf.Abs(_movementInputValue) > 0.1f || Mathf.Abs(_turnInputValue) > 0.1f)
        {
            int i = 0;
            foreach (Transform child in Feet.transform)
            {
                float currentPosY = Mathf.PingPong(Time.time + 0.05f*i, 0.1f) + FootMinYPos;
                child.localPosition = new Vector3(child.localPosition.x, currentPosY, child.localPosition.z);
                i++;
            }
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blanket") && NumberOfBlankets < MaxNumberOfBlankets)
        {
            AudioController.PlayAudio(false);
        }
        base.OnTriggerEnter(other);
    }
}

