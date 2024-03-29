using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float speed = 12;
    [SerializeField] private float range = 0.5f;
    [SerializeField] private float maxDistance;
    [SerializeField] private bool seenPlayer;
    [SerializeField] private bool checkingDistance;

    public GameObject Pistol;
    public GameObject Shotgun;
    public GameObject Rifle;
    public GameObject player;

    public Gun gun;
    public GunType enemygun;
    private PlayerHealth playerhealth;

    private Vector2 wayPoint;
    [SerializeField]private int gunnumber;
    public float distance;

    private void Start()
    {
        checkingDistance = false;
        player = GameObject.FindGameObjectWithTag("Player");
        playerhealth = player.GetComponent<PlayerHealth>();
        SetNewDestination();
        gunnumber = Random.Range(0, 3);
        if (gunnumber == 0)
        {
            enemygun = GunType.Handgun;
            Pistol.SetActive(true);
            Shotgun.SetActive(false);
            Rifle.SetActive(false);
            gun = Pistol.GetComponent<Pistol>();
        }
        else if (gunnumber == 1)
        {
            enemygun = GunType.Shotgun;
            Pistol.SetActive(false);
            Shotgun.SetActive(true);
            Rifle.SetActive(false);
            gun = Shotgun.GetComponent<Shotgun>();
        }
        else if (gunnumber == 2)
        {
            enemygun = GunType.Rifle;
            Pistol.SetActive(false);
            Rifle.SetActive(true);
            Shotgun.SetActive(false);
            gun = Rifle.GetComponent<Rifle>();
        }
    }

    private void Update()
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

        if (distance <= 28 && distance > 20) // Looks at Player
        {
            seenPlayer = true;
            transform.right = player.transform.position - transform.position;
            DistanceChecking();
        }
        else if (distance <= 20) // Shoots at Player
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
    
    private IEnumerator DistanceChecked()
    {
        yield return new WaitForSeconds(5f);
        SetNewDestination();
    }

    private void DistanceChecking()
    {
        if(!checkingDistance)
        {
            checkingDistance = true;
            StartCoroutine(DistanceChecked());
        }
    }
}
