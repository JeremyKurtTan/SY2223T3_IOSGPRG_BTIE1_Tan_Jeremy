using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] GreenArrowTypes;
    public GameObject[] RedArrowTypes;
    public GameObject[] RotatingArrowTypes;
    public Transform location;
    void Start()
    {
        StartCoroutine(EnemyTimer());
    }

    public void SpawnRandom()
    {
        int ArrowTypeSpawn = Random.Range(0, 2);
        int GAT = Random.Range(0, GreenArrowTypes.Length);
        int RAT = Random.Range(0, RedArrowTypes.Length);
        int RotaAT = Random.Range(0, RotatingArrowTypes.Length);
        if (ArrowTypeSpawn == 0)
        {
            Instantiate(GreenArrowTypes[GAT], location.position, Quaternion.identity);
        }
        else if (ArrowTypeSpawn == 1)
        {
            Instantiate(RedArrowTypes[RAT], location.position, Quaternion.identity);
        }
        else if (ArrowTypeSpawn == 2)
        {
            Instantiate(RotatingArrowTypes[RotaAT], location.position, Quaternion.identity);
        }
    }

    private IEnumerator EnemyTimer()
    {
        SpawnRandom();
        float SpawnTimer = Random.Range(1, 2.5f);
        yield return new WaitForSeconds(SpawnTimer);
        StartCoroutine(EnemyTimer());
    }
}
