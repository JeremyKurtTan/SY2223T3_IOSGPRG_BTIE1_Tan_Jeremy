using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefense : MonoBehaviour
{
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            health -= 20;
            Destroy(gameObject);
        }
    }
}
