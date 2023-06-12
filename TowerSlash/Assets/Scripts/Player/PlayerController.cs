using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Idle,
    isLeft,
    isRight,
    isUp,
    isDown,
    All
}
public class PlayerController : MonoBehaviour
{ 
    public Rigidbody2D rb;
    public static int moveSpeed;
    public static Direction CurrentDirection;
    public static bool isDashing;
    public int maxDashBar = 100;
    public static int currentDashBar;
    public DashMeterBar dashMeterBar;

    private Vector2 StartTouchPosition;
    private Vector2 EndTouchPosition;
    private Vector2 currentSwipe;

    public void Start()
    {
        currentDashBar = maxDashBar;
        dashMeterBar.setMaxDashMeter(maxDashBar);

        CurrentDirection = Direction.Idle;
        moveSpeed = 4;

        isDashing = false;
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

            if (EndTouchPosition.x < StartTouchPosition.x && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                CurrentDirection = Direction.isLeft;
            }
            if (EndTouchPosition.x > StartTouchPosition.x && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                CurrentDirection = Direction.isRight;
            }
            if (EndTouchPosition.y > StartTouchPosition.y && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                CurrentDirection = Direction.isUp;
            }
            if (EndTouchPosition.y < StartTouchPosition.y && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                CurrentDirection = Direction.isDown;
            }
        }

        if(DestroyArrow.destroyed == true)
        {
            print(currentDashBar);
            currentDashBar += 5;
            dashMeterBar.SetDashMeter(currentDashBar);
        }
        if(isDashing == true)
        {
            currentDashBar = 0;
            dashMeterBar.SetDashMeter(currentDashBar);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isDashing == true)
        {
            CurrentDirection = Direction.All;
        }
        else
        {
            CurrentDirection = Direction.Idle;
        }
    }
}

