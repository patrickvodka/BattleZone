using System;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    
    public float speed = 15f;
    Vector2 horizontalInput;
    public float turnSmoothTime = 0.1f;
    private Rigidbody Rb;
    private Vector3 AngleX;
    public Vector3 Direction;
    public Transform Self;
    private GameObject CheckObj;
    public int Life = 3;
    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
        Self = GetComponent<Transform>();
       CheckObj = GameObject.Find("Check");
    }

    public void OnMovePressed(InputAction.CallbackContext obj)
    {
        horizontalInput = obj.ReadValue<Vector2>();
    }

    public void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        //<>
        Direction = (transform.position.normalized + CheckObj.transform.position).normalized;
        Direction.y = 0;
        AngleX = new Vector3(horizontalInput.x, 0, 0);

        if (horizontalInput.y >= 0f)
        {
            Rb.velocity = ((Direction * speed ) * Time.deltaTime);
        }
        if (horizontalInput.y <= 0f)
        {
            Rb.velocity = ((Direction*-1) * speed ) * Time.deltaTime;
        }
        if(horizontalInput.x !=0f )
        {
            Self.Rotate(0,AngleX.x*turnSmoothTime,0);
        }
        if (horizontalInput.y == 0f)
        {
            Rb.velocity = new Vector3(0,0,0);
        }
        if(Life <= 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
