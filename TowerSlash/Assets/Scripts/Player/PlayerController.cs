using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public int moveSpeed;

    private Vector2 StartTouchPosition;
    private Vector2 EndTouchPosition;

    private void Start()
    {
        moveSpeed = 5;
    }
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, transform.localScale.y * moveSpeed);
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            StartTouchPosition = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            EndTouchPosition = Input.GetTouch(0).position;

            if(EndTouchPosition.x < StartTouchPosition.x)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * -moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
            if (EndTouchPosition.x > StartTouchPosition.x)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
        }

















        /*if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            transform.position = touchPosition;

        }*/
    }
}
