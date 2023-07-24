using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    [SerializeField] private float range = 0.5f;
    [SerializeField] private float maxDistance;

    private bool seenPlayer;
    public GameObject player;

    private Vector2 wayPoint;
    public float distance;

    private void Start()
    {
        SetNewDestination();
    }

    private void Update()
    {
        if(!seenPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, wayPoint) < range)
            {
                SetNewDestination();
            }
        }

        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance <= 20)
        {
            seenPlayer = true;
            transform.right = player.transform.position - transform.position;
        }
        else
        {
            seenPlayer = false;
        }
    }

    private void SetNewDestination()
    {
        wayPoint = new Vector2(transform.position.x + Random.Range(-maxDistance, maxDistance), transform.position.y + Random.Range(-maxDistance, maxDistance));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            wayPoint = new Vector2(transform.position.x + Random.Range(-maxDistance, maxDistance), transform.position.y + Random.Range(-maxDistance, maxDistance));
        }
    }
    

}
