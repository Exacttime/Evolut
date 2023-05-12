using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public Transform playerTransform;

    public float moveSpeed = 1f;
    [SerializeField] private float jumpForce = 0f;
    [SerializeField] private float healthLife = 0f;
    private bool isMoving = false;

    private Rigidbody rigidBody;

    public CharacterController characterController;

    public void Start()
    {
    rigidBody = GetComponent<Rigidbody>();
    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0f , transform.localEulerAngles.z);
    }
    void Update()
    {

        isMoving = false;

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            GetComponent<Rigidbody>().velocity += transform.right * Input.GetAxisRaw("Horizontal") * moveSpeed;
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            //transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * playerSpeed);
            GetComponent<Rigidbody>().velocity += transform.forward * Input.GetAxisRaw("Vertical") * moveSpeed;
            isMoving = true;
        }
        /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A");
            // characterController.SimpleMove(novaPosition * moveSpeed * Time.deltaTime);
           playerTransform.position = new Vector3(playerTransform.position.x + moveSpeed * Time.deltaTime, 0f, playerTransform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("A");
            // characterController.SimpleMove(novaPosition * moveSpeed * Time.deltaTime);
            playerTransform.position = new Vector3(playerTransform.position.x - moveSpeed * Time.deltaTime, 0f, playerTransform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("A");
            // characterController.SimpleMove(novaPosition * moveSpeed * Time.deltaTime);
            playerTransform.position = new Vector3(playerTransform.position.x,0f, playerTransform.position.z + moveSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("A");
            // characterController.SimpleMove(novaPosition * moveSpeed * Time.deltaTime);
            playerTransform.position = new Vector3(playerTransform.position.x, 0f, playerTransform.position.z - moveSpeed * Time.deltaTime);
            
        }
        */

    }
}