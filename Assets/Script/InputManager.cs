using System.Collections;
using System.Collections.Generic;
using UnityEngine;/*

public class InputManager : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    Vector2 mouseInput;
    PlayerControls controls; 
    PlayerControls.GroundMovementActions groundMovement; 
    Vector2 horizontalInput;
    private void Awake()
    {
        controls = new PlayerControls();
        groundMovement = controls.GroundMovement;
        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

        

    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDestroy()
    {
        controls.Disable();
    }

    private void Update()
    {
        playerMovement.ReceiveInput(horizontalInput);
        
    }
} */