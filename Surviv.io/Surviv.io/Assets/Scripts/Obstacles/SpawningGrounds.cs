using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningGrounds : MonoBehaviour
{
    public Vector2 cubeSize;
    public Vector2 cubeCenter;
    public GameObject bossSpawnlocation;
    public GameObject Boss;

    public GameObject[] Guns;
    public GameObject Enemies;
    public GameObject[] Ammo;
    public GameObject stimpack;

    public BoxCollider2D spawnPoints;
    [SerializeField] private int ItemSpawning = 40;
    [SerializeField] private int EnemySpawning = 6;
    [SerializeField] private int itemspawnSelect;


    private void Awake()
    {
        spawnPoints = this.GetComponent<BoxCollider2D>();

        Transform cubeTrans = spawnPoints.GetComponent<Transform>();
        cubeCenter = cubeTrans.position;

        cubeSize.x = cubeTrans.localScale.x * spawnPoints.size.x;
        cubeSize.y = cubeTrans.localScale.y * spawnPoints.size.y;
    }

    private void Start()
    {
        for (int i = 0; i < ItemSpawning; i++)
        {
            SpawnItems();
        }
        for (int i = 0; i < EnemySpawning; i++)
        {
            SpawnEnemies();
        }
        StartCoroutine(BossSpawn());
    }

    private void SpawnEnemies()
    {
        Instantiate(Enemies, GetRandomPosition(), Quaternion.identity);
    }

    private void SpawnItems()
    {
        itemspawnSelect = Random.Range(0, 9);
        if (itemspawnSelect == 0)
            Instantiate(stimpack, GetRandomPosition(), Quaternion.identity);
        else if (itemspawnSelect >= 1 && itemspawnSelect <= 6)
            Instantiate(Ammo[Random.Range(0, Ammo.Length)], GetRandomPosition(), Quaternion.identity);
        else if(itemspawnSelect >= 7)
            Instantiate(Guns[Random.Range(0, Guns.Length)], GetRandomPosition(), Quaternion.identity);

    }

    public Vector2 GetRandomPosition()
    {
        Vector2 RandomPosition = new Vector2(Random.Range(-cubeSize.x / 2, cubeSize.x / 2), Random.Range(-cubeSize.y / 2, cubeSize.y / 2));

        return cubeCenter + RandomPosition;
    }
    
    IEnumerator BossSpawn()
    {
        yield return new WaitForSeconds(5f);
        Instantiate(Boss, bossSpawnlocation.transform.position, Quaternion.identity) ;
    }
}
