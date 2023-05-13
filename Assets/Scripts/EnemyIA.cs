using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rangeToChasePlayer = 10f;

    [SerializeField] Rigidbody enemyRigidbody;
    [SerializeField] Vector3 direction;
    private bool chasingPlayer = false;
    [SerializeField] GameObject player;

    void Start()
    { 
        direction = RandomDirection();
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= rangeToChasePlayer)
            {
                //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed).;
                direction = (player.transform.position - transform.position).normalized;
                chasingPlayer = true;
            }
            else
            {
                if (chasingPlayer)
                {
                    direction = RandomDirection();
                    chasingPlayer = false;
                    Debug.Log("Parou de seguir:");
                }
            }

            enemyRigidbody.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
        }
    }

    private Vector3 RandomDirection()
    {
        return new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }
}