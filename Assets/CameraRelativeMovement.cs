using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraRelativeMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [Header("Vetores")]
    Vector3 playerInput;
    Vector3 cameraRelativeMovement;
    [Header("Floats")]
    float horizontalInput;
    float verticalInput;
    float rotationFactorPerFrame = 15.0f;
    [Space]
    bool isMovementPressed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        HandleRotation();
        Movement();
    }
    #region Input e Valores
    private void Movement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        playerInput.x = horizontalInput * 2;
        playerInput.z = verticalInput * 2;
        cameraRelativeMovement = ConvertToCameraSpace(playerInput);
        characterController.Move(cameraRelativeMovement * Time.deltaTime);
    }
    #endregion
    #region Mecanismos para rotação e movimentação
    Vector3 ConvertToCameraSpace(Vector3 vectorRotate)
    {
        float currentYValue = vectorRotate.y;
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;

        Vector3 cameraForwardProductZ = vectorRotate.z * cameraForward;
        Vector3 cameraRightProductx = vectorRotate.x * cameraRight;

        Vector3 rotateResultWorldSpace = cameraForwardProductZ + cameraRightProductx;
        rotateResultWorldSpace.y = currentYValue;
        return rotateResultWorldSpace;
    }
    void HandleRotation()
    {
        Vector3 positionToLookAt;
        positionToLookAt.x = cameraRelativeMovement.x;
        positionToLookAt.y = 0;
        positionToLookAt.z = cameraRelativeMovement.z;

        Quaternion currentRotation = transform.rotation;
        if (isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }
    }
    #endregion
}
