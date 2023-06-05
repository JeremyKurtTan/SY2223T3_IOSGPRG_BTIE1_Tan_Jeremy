using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefense : MonoBehaviour
{
    GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (PlayerController.isLeft == true)
       {
           enemy = GameObject.Find("LeftArrow");
           Destroy(enemy);
           PlayerController.isLeft = false;
       }
       if (PlayerController.isRight == true)
       {
            enemy = GameObject.Find("RightArrow");
            Destroy(enemy);
            PlayerController.isRight = false;
        }
       if (PlayerController.isUp == true)
       {
            enemy = GameObject.Find("UpArrow");
            Destroy(enemy);
            PlayerController.isUp = false;
        }
       if (PlayerController.isDown == true)
       {
            enemy = GameObject.Find("DownArrow");
            Destroy(enemy);
            PlayerController.isDown = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerDefense.health -= 50;
        }
    }
}
