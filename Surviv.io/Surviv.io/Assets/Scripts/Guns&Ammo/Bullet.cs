using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("Life", 1.5f);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
    }
    
    void Life()
    {
        Destroy(gameObject);
    }
}
