using System;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    //Assigned on start
    Rigidbody m_rb = null;
    private Vector3 playerScale;
    private float tempSpeed;
    
    //Assignables
    [SerializeField] float m_speed = 20.0f;
    //[SerializeField] float slideForce = 400;
    [SerializeField] Transform m_orientation = null;
    [SerializeField] Transform m_groundCheck = null;
    [SerializeField] float m_crouchSpeed = 10.0f;
    [SerializeField] float m_counterMovement = 0.175f;
    [SerializeField] float m_maxSpeed = 20;
    [SerializeField] float slideCounterMovement = 0.2f;
    [SerializeField] float m_groundDistance = 0.4f;
    [SerializeField] LayerMask m_groundMask;
    [SerializeField] float m_jumpForce = 4.0f;
    [SerializeField] float m_gravity = -9.81f;

    //Private variables
    private bool crouching;
    private Vector3 crouchScale = new Vector3(1, 0.60f, 1);
    private bool grounded, jumping, readyToJump = true;
    private Vector3 moveForce;
    private float threshold = 0.01f;
    private Vector3 normalVector = Vector3.up;
    private float jumpCooldown = 0.25f;


    private void Start()
    {
        tempSpeed = m_speed;
        playerScale = transform.localScale;
        m_rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerMovement();
        m_rb.AddForce(Vector3.down * Time.deltaTime * m_gravity);
    }

    private void PlayerMovement()
    {
        //Debug.Log(m_groundMask);
        grounded = Physics.CheckSphere(m_groundCheck.position, m_groundDistance, m_groundMask);


        Vector3 moveTo = Vector3.zero;

        moveTo.x = Input.GetAxisRaw("Horizontal");
        moveTo.z = Input.GetAxisRaw("Vertical");
        jumping = Input.GetButtonDown("Jump");

        moveForce = moveTo * m_speed;

        m_rb.AddRelativeForce(moveForce, ForceMode.Acceleration);

        m_rb.velocity = Vector3.ClampMagnitude(m_rb.velocity, m_speed);

        if (readyToJump && jumping)
        {
            Jump();
        }

        crouching = Input.GetKey(KeyCode.LeftControl);

        //Crouching
        if (Input.GetKeyDown(KeyCode.LeftControl)) StartCrouch();
        if (Input.GetKeyUp(KeyCode.LeftControl)) StopCrouch();

        Vector2 mag = FindVelRelativeToLook(); 

        CounterMovement(moveTo.x, moveTo.y, mag);
    }

    private void Jump()
    {
        if (grounded && readyToJump)
        {
            readyToJump = false;

            //Add jump forces
            m_rb.AddForce(Vector2.up * m_jumpForce * 1.5f);
            m_rb.AddForce(normalVector * m_jumpForce * 0.5f);

            //If jumping while falling, reset y velocity.
            Vector3 vel = m_rb.velocity;
            if (m_rb.velocity.y < 0.5f)
                m_rb.velocity = new Vector3(vel.x, 0, vel.z);
            else if (m_rb.velocity.y > 0)
                m_rb.velocity = new Vector3(vel.x, vel.y / 2, vel.z);

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    public Vector2 FindVelRelativeToLook()
    {
        float lookAngle = m_orientation.transform.eulerAngles.y;
        float moveAngle = Mathf.Atan2(m_rb.velocity.x, m_rb.velocity.z) * Mathf.Rad2Deg;

        float u = Mathf.DeltaAngle(lookAngle, moveAngle);
        float v = 90 - u;

        float magnitue = m_rb.velocity.magnitude;
        float yMag = (magnitue - m_rb.velocity.y) * Mathf.Cos(u * Mathf.Deg2Rad);
        float xMag = (magnitue - m_rb.velocity.x) * Mathf.Cos(v * Mathf.Deg2Rad);

        return new Vector2(xMag, yMag);
    }

    private void CounterMovement(float x, float y, Vector2 mag)
    {
        if (!grounded || jumping) return;

        //Slow down sliding
        if (crouching)
        {
            m_rb.AddForce(m_speed * Time.deltaTime * -m_rb.velocity.normalized * slideCounterMovement);
            return;
        }

        //Counter movement
        if (Math.Abs(mag.x) > threshold && Math.Abs(x) < 0.05f || (mag.x < -threshold && x > 0) || (mag.x > threshold && x < 0))
        {
            m_rb.AddForce(m_speed * m_orientation.transform.right * Time.deltaTime * -mag.x * m_counterMovement);
        }
        if (Math.Abs(mag.y) > threshold && Math.Abs(y) < 0.05f || (mag.y < -threshold && y > 0) || (mag.y > threshold && y < 0))
        {
            m_rb.AddForce(m_speed * m_orientation.transform.forward * Time.deltaTime * -mag.y * m_counterMovement);
        }

        //Limit diagonal running. This will also cause a full stop if sliding fast and un-crouching, so not optimal.
        if (Mathf.Sqrt((Mathf.Pow(m_rb.velocity.x, 2) + Mathf.Pow(m_rb.velocity.z, 2))) > m_maxSpeed)
        {
            float fallspeed = m_rb.velocity.y;
            Vector3 n = m_rb.velocity.normalized * m_maxSpeed;
            m_rb.velocity = new Vector3(n.x, fallspeed, n.z);
        }
    }

    private void StartCrouch()
    {
        transform.localScale = crouchScale;
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.8f, transform.position.z);
        crouching = true;
        //Debug.Log(m_rb.velocity.magnitude);
        m_speed = m_crouchSpeed;

        //slide mechanic is here
        //if (m_rb.velocity.magnitude > 0.5f)
        //{
        //    if (grounded)
        //    {
        //        m_rb.AddForce(m_orientation.transform.forward * slideForce);
        //    }
        //}
    }

    private void StopCrouch()
    {
        transform.localScale = playerScale;
        crouching = false;
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.6f, transform.position.z);
        m_speed = tempSpeed;
    }
}
