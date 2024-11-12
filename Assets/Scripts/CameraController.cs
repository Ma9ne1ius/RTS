using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraСontroller : MonoBehaviour
{
    [Header("Camera Movement Settings")]
    public float moveSpeed = 2f;
    public float edgeScrollThreshold = 10f;
    public float scrollSpeed = 10f;
    public float minZoom = 10f;
    public float maxZoom = 100f;
    public float boostMultiplier = 2f;
    public float rotationSpeed = 2f;

    [SerializeField]

    private KeyCode horRotationKey = KeyCode.LeftControl;
    private KeyCode shiftKey = KeyCode.LeftShift;
    private KeyCode verRotationKey = KeyCode.LeftAlt;



    [Header("Map Boundaries Object")]
    public GameObject mapBoundaryObject;

    public Camera cam ;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        HandleKeyboardMovement();
        HandleHorCameraRotation(Input.GetKey(horRotationKey));

        // HandleMouseMovement();
        HandleZoom();
        // ClampCameraPosition();

    }


    private void HandleKeyboardMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput == 0 && verticalInput == 0)
            return;

        Transform cameraTransform = cam.transform;
        Vector3 cameraForward = new Vector3(cameraTransform.forward.x, 0, cameraTransform.forward.z).normalized;
        Vector3 cameraRight = new Vector3(cameraTransform.right.x, 0, cameraTransform.right.z).normalized;

        float currentMoveSpeed = moveSpeed;
        if (Input.GetKey(shiftKey))
        {
            currentMoveSpeed *= boostMultiplier;
        }

        Vector3 moveDirection = cameraForward * verticalInput + cameraRight * horizontalInput;

        transform.Translate(moveDirection * currentMoveSpeed, Space.World);
    }

    private void HandleMouseMovement()
    {
        Vector3 moveDirection = Vector3.zero;
        Vector2 mousePosition = Input.mousePosition;

        if (mousePosition.x >= Screen.width - edgeScrollThreshold)
        {
            moveDirection += Vector3.right;
        }
        if (mousePosition.x <= edgeScrollThreshold)
        {
            moveDirection += Vector3.left;
        }
        if (mousePosition.y >= Screen.height - edgeScrollThreshold)
        {
            moveDirection += Vector3.forward;
        }
        if (mousePosition.y <= edgeScrollThreshold)
        {
            moveDirection += Vector3.back;
        }


        transform.Translate(moveDirection.normalized * moveSpeed, Space.World);
    }

    private void HandleHorCameraRotation(bool flag)
    {

        if (flag)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            float mouseX = Input.GetAxis("Mouse X");

            transform.Rotate(Vector3.up, mouseX * rotationSpeed, Space.World);
        }
        else if ((Cursor.lockState == CursorLockMode.Locked || Cursor.visible == false) && !flag)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            return;
        }
    }

    private void HandleZoom()
    {
        Vector3 direction = transform.forward;

        Vector3 targetPoint = GetTargetPoint();

        float zoomAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;

        if (zoomAmount == 0f)
        {
            return;
        }

        Vector3 newPosition = transform.position + direction * zoomAmount;

        float distance = Vector3.Distance(newPosition, targetPoint);
        if (distance >= minZoom && distance <= maxZoom)
        {
            transform.position = newPosition;
        }
    }
    private Vector3 GetTargetPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }

        return transform.position;
    }

    private void ClampCameraPosition()
    {
        Collider boundaryCollider = mapBoundaryObject.GetComponent<Collider>();

        Vector3 minBounds = boundaryCollider.bounds.min;
        Vector3 maxBounds = boundaryCollider.bounds.max;

        Vector3 position = transform.position;

        position.x = Mathf.Clamp(position.x, minBounds.x, maxBounds.x);
        position.z = Mathf.Clamp(position.z, minBounds.z, maxBounds.z);

        transform.position = position;
    }
}
