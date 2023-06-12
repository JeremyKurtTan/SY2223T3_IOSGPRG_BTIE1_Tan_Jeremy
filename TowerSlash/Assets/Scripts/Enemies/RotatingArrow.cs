using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingArrow : MonoBehaviour
{
    public float moveSpeed;
    private void Start()
    {
        moveSpeed = 1.3f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 0);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, transform.localScale.y * moveSpeed);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector3(1f, 1f, 0);
    }
}
