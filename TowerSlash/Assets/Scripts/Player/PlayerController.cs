using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public int moveSpeed;

    private Vector2 StartTouchPosition;
    private Vector2 EndTouchPosition;
    private Vector2 currentSwipe;

    [SerializeField]
    public static bool isLeft;
    public static bool isRight;
    public static bool isUp;
    public static bool isDown;

    private void Start()
    {
        moveSpeed = 5;
        isLeft = false;
        isRight = false;
        isUp = false;
        isDown = false;
    }
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, transform.localScale.y * moveSpeed);
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            StartTouchPosition = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            EndTouchPosition = Input.GetTouch(0).position;

            currentSwipe = new Vector2(EndTouchPosition.x - StartTouchPosition.x, EndTouchPosition.y - StartTouchPosition.y);
            currentSwipe.Normalize();

            if (EndTouchPosition.x < StartTouchPosition.x && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) isLeft = true;
            if (EndTouchPosition.x > StartTouchPosition.x && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) isRight = true;
            if (EndTouchPosition.y > StartTouchPosition.y && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) isUp = true;
            if (EndTouchPosition.y < StartTouchPosition.y && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) isDown = true;
        }
    }
}
