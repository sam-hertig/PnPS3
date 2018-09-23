using UnityEngine;

public class PookieController : BeingController
{       
    public float m_Speed = 5f;            
    public float m_TurnSpeed = 180f;
    public GameObject feet;
    public float footMinYPos = -0.52f;

    private Rigidbody m_Rigidbody;         
    private float m_MovementInputValue = 0f;    
    private float m_TurnInputValue = 0f;


    protected override void Awake ()
    {
        base.Awake();
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    protected override void Update ()
    {
        base.Update();
        m_MovementInputValue = Input.GetAxis ("Vertical");
        m_TurnInputValue = Input.GetAxis ("Horizontal");
        WiggleFeet();
    }


    private void FixedUpdate ()
    {
        Move ();
        Turn ();
    }


    private void Move ()
    {
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
        if (transform.position.y < -10) {
            gameManager.gameOver();
        }
    }


    private void Turn ()
    {
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);
        m_Rigidbody.MoveRotation (m_Rigidbody.rotation * turnRotation);
    }


    private void WiggleFeet ()
    {
        if (Mathf.Abs(m_MovementInputValue) > 0.1f || Mathf.Abs(m_TurnInputValue) > 0.1f)
        {
            int i = 0;
            foreach (Transform child in feet.transform)
            {
                float currentPosY = Mathf.PingPong(Time.time + 0.05f*i, 0.1f) + footMinYPos;
                child.localPosition = new Vector3(child.localPosition.x, currentPosY, child.localPosition.z);
                i++;
            }
        }
    }
}

