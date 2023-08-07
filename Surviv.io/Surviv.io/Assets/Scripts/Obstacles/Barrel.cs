using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] private int health = 2;
    [SerializeField] private int lootTable;
    [SerializeField] private GameObject[] gunDrop;
    [SerializeField] private GameObject[] ammoDrop;
    [SerializeField] private GameObject stimpacks;

    private void Start()
    {
        lootTable = Random.Range(0, 9);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bullet bulleth = collision.gameObject.GetComponent<Bullet>();
        if(bulleth  != null)
        {
            this.gameObject.transform.localScale -= new Vector3(0.015f, 0.025f, 0);
            health--;
            Destroyed();
        }
    }

    private void Destroyed()
    {
        if(health == 0)
        {
            Destroy(gameObject);
            DropLoot();
        }
    }

    private void DropLoot()
    {
        if(lootTable <= 2 && lootTable != 0)
        {
            Instantiate(gunDrop[Random.Range(0, gunDrop.Length)], this.transform.position, Quaternion.identity);
        }
        else if(lootTable >= 3)
        {
            Instantiate(ammoDrop[Random.Range(0, ammoDrop.Length)], this.transform.position, Quaternion.identity);
        }
        else if(lootTable == 0)
        {
            Instantiate(stimpacks, this.transform.position, Quaternion.identity);
        }
    }
}
