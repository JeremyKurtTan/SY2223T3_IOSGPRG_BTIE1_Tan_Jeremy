using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] EnemyTypes;
    public Transform location;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyTimer());

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SpawnRandom()
    {
        int RandomEnemy = Random.Range(0,EnemyTypes.Length);
        Instantiate(EnemyTypes[RandomEnemy], location.position, Quaternion.identity) ;
    }

    private IEnumerator EnemyTimer()
    {
        SpawnRandom();
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(EnemyTimer());
    }
}
