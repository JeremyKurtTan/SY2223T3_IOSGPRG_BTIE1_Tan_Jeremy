using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningGrounds : MonoBehaviour
{
    public Vector2 cubeSize;
    public Vector2 cubeCenter;

    public GameObject[] items;

    public BoxCollider2D spawnPoints;
    int ItemSpawning = 30;

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

    }

    void SpawnItems()
    {
        Instantiate(items[Random.Range(0, items.Length)], GetRandomPosition(), Quaternion.identity);
    }

    public Vector2 GetRandomPosition()
    {
        Vector2 RandomPosition = new Vector2(Random.Range(-cubeSize.x / 2, cubeSize.x / 2), Random.Range(-cubeSize.y / 2, cubeSize.y / 2));

        return cubeCenter + RandomPosition;
    }
}
