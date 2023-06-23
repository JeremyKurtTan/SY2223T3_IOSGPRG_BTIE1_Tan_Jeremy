using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArrow : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    GameObject player;
    public static bool destroyed = false;

    void Start()
    {
        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (destroyed == true)
            {
                Destroy(gameObject);
                destroyed = false;
                int Extralife = Random.Range(0, 100);
                if (Extralife <= 3)
                {
                    playerHealth.health += 1;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (destroyed) return;
            else
            {
                playerHealth.health -= 1;
            }
        }
    }
}
