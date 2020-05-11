using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    [SerializeField] [Range(50, 300)] float m_mouseSensitivity = 100.0f;
    [SerializeField] public Transform target, player = null;
    [SerializeField] [Range(0, 5)] float m_distance = 5.0f;

    float mouseX;
    float mouseY;

    float yaw = 0.0f;
    float pitch = 0.0f;

    private float xRotation = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * m_mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * m_mouseSensitivity * Time.deltaTime;

        yaw += mouseX;
        //yaw = Mathf.Clamp(yaw, -70.0f, 70.0f);
        Quaternion qyaw = Quaternion.AngleAxis(yaw, Vector3.up);

        if (Input.GetKeyDown(KeyCode.Equals) && m_distance < 5.0f)
        {
            m_distance++;
        }
        
        if (Input.GetKeyDown(KeyCode.Minus) && m_distance > 0.0f)
        {
            m_distance--;
        }

        pitch += mouseY;
        pitch = Mathf.Clamp(pitch, -75.0f, 80.0f);
        Quaternion qpitch = Quaternion.AngleAxis(-pitch, Vector3.right);
        
        
        
        target.rotation = qyaw * qpitch;
        player.rotation = qyaw;
        //target.Rotate(Vector3.right, mouseY);
        
        Quaternion rotation = target.rotation * Quaternion.AngleAxis(mouseX, Vector3.up) * Quaternion.AngleAxis(mouseY, Vector3.right);
        Vector3 newPos = target.position + rotation * new Vector3(0, 0, -m_distance);

        if (Physics.Raycast(target.position, newPos - target.position, out RaycastHit hit, m_distance))
        {
            newPos = hit.point;
        }
        transform.position = /*newPos*/Vector3.Lerp(transform.position, newPos, Time.deltaTime * 10.0f);
    }
}