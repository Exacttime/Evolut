using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public partial class PlayerController : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] public GameObject player;
    [SerializeField] public Transform playerTransform;
    [SerializeField] public Rigidbody rigidBody;
    [Space]
    [Header("Valores")]
    [SerializeField] private float jumpForce = 0f;
    [SerializeField] private float healthLife = 0f;
    [SerializeField] public float ray = 0.7f; // ray do Raycast

    public LayerMask floorLayer;
    public CharacterController characterController;

    public float moveSpeed = 1f;

    private bool isGrounded;
    private bool isOnFloor = false;
    private bool isMoving = false;

    public void Start()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0f, transform.localEulerAngles.z);
    }
    void Update()
    {
        isMoving = false;
        #region Movimentação
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            rigidBody.velocity += transform.right * Input.GetAxisRaw("Horizontal") * moveSpeed;
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        { 
            rigidBody.velocity += transform.forward * Input.GetAxisRaw("Vertical") * moveSpeed;
            isMoving = true;
        }
        if (IsGrounded() == true && Input.GetButtonDown("Jump"))
        {
            rigidBody.AddForce(new Vector3(0, 20, 0), ForceMode.Impulse);
        }
        #endregion
    }
    private bool IsGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, ray, floorLayer))
        {

            return true;
        }
        else
        {
            return false;
        }
    }

}