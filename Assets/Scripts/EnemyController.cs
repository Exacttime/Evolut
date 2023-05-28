using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rangeToChasePlayer = 10f;

    [SerializeField] Rigidbody enemyRigidbody;
    [SerializeField] Vector3 direction;
    private bool chasingPlayer = false;
    [SerializeField] GameObject player;

    public float fieldOfViewAngle = 90f;

    void Start()
    { 
        //direction = RandomDirection();
    }

    void Update()
    {
        Vector3 directionToPlayer = player.transform.position - transform.position;

        float angle = Vector3.Angle(transform.forward, directionToPlayer);
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if(angle < fieldOfViewAngle)
            {
                RaycastHit hit;
                if(Physics.Linecast(transform.position, player.transform.position, out hit))
                {
                    if(hit.collider.gameObject == player)
                    {
                        ChasePlayer();
                        chasingPlayer = true;
                        Debug.Log("Encontrei o player");
                    }
                }
            }




            /*
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
            */
            enemyRigidbody.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
        
    }

    private void ChasePlayer()
    {
        Vector3 directionToPlayer = player.transform.position - transform.position;
        directionToPlayer.Normalize();

        Vector3 targetPosition = transform.position + directionToPlayer * moveSpeed * Time.deltaTime;
        enemyRigidbody.MovePosition(targetPosition);
    }
    private Vector3 RandomDirection()
    {
        return new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }
}