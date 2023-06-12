using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArrow : MonoBehaviour
{
    public static bool destroyed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        destroyed = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (destroyed == true)
            {
                Destroy(gameObject);
                destroyed = false;
                int Extralife = Random.Range(0, 100);
                if(Extralife <= 3)
                {
                    PlayerHealth.health += 1;
                }
            }
        }
    }
}
