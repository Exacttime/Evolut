using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public Transform playerTransform;

    public float moveSpeed = 0f;
    [SerializeField] private float jumpForce = 0f;
    [SerializeField] private float healthLife = 0f;

    public CharacterController characterController;

    public void Start()
    {

    }
    void Update()
    {
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

    }
}