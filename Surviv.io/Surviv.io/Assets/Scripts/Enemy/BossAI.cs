using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    [SerializeField] private float speed = 7;
    [SerializeField] private float range = 0.5f;
    [SerializeField] private float maxDistance;
    [SerializeField] private bool seenPlayer;

    public GameObject RocketLauncher;
    public Gun gun;
    public GunType enemygun;
    private PlayerHealth playerhealth;
    public GameObject player;


    private Vector2 wayPoint;
    [SerializeField] private int gunnumber;
    public float distance;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerhealth = player.GetComponent<PlayerHealth>();
        SetNewDestination();
        gun = RocketLauncher.GetComponent<RocketLauncher>();
    }

    void Update()
    {
        if (playerhealth.isPlayerDead)
            return;

        if (!seenPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, wayPoint) < range)
            {
                SetNewDestination();
            }
        }

        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance <= 28 && distance > 20)
        {
            seenPlayer = true;
            transform.right = player.transform.position - transform.position;
        }
        else if (distance <= 20)
        {
            transform.right = player.transform.position - transform.position;
            gun.EnemyShoot();
            seenPlayer = true;
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
        transform.rotation = Quaternion.Euler(0, 0, -90);
        wayPoint = new Vector2(transform.position.x + Random.Range(-maxDistance, maxDistance), transform.position.y + Random.Range(-maxDistance, maxDistance));
    }
}
