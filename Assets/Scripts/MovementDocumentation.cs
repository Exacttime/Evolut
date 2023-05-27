using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementDocumentation : MonoBehaviour
{
    float velocity = 10f;
    [SerializeField] private Vector3 player = new Vector3();
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody playerRigidbody;

    private void Start()
    {

    }

    void Update()
    {
        if (Input.GetAxisRaw("Vertical") > 0.5 || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            playerRigidbody.position += new Vector3(velocity * Time.deltaTime, 0, 0);
        }
    }
}
