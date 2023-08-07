using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private GameObject explosionCircle;
    [SerializeField] private CircleCollider2D explosion;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("Despawn", 3f);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
    }

    void Despawn()
    {
        StartCoroutine(Explosion());
        Debug.Log("Boom");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Explosion());
        Debug.Log("Boom");
    }

    private void GoBoom()
    {
        explosion.radius = 0.5f;
    }

    IEnumerator Explosion()
    {
        explosionCircle.SetActive(true);
        GoBoom();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
