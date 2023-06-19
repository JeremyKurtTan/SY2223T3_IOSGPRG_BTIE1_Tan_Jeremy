using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    PlayerHealth playerHealth;
    GameObject player;

    public Rigidbody2D rb;
    public int moveSpeed = 4;
    public Direction CurrentDirection;
    public bool isSmallDashing;
    public bool isDashing;
    public int maxDashBar = 100;
    public int currentDashBar;
    public int dashIncreaseValue = 5;
    public DashMeterBar dashMeterBar;

    private Vector2 StartTouchPosition;
    private Vector2 EndTouchPosition;
    private Vector2 currentSwipe;

    public void Start()
    {
        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

        currentDashBar = maxDashBar;
        dashMeterBar.setMaxDashMeter(maxDashBar);

        CurrentDirection = Direction.Idle;
        isSmallDashing = false;
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

            if(EndTouchPosition.x == StartTouchPosition.x && EndTouchPosition.y == StartTouchPosition.y)
            {
                if (!isSmallDashing)
                {
                    StartCoroutine(SmallDashPlayer());
                }
                else return;
            }
        }

        if(isDashing == true)
        {
            currentDashBar = 0;
            dashMeterBar.SetDashMeter(currentDashBar);
        }

        if (currentDashBar > maxDashBar)
            currentDashBar = maxDashBar;

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

    IEnumerator SmallDashPlayer()
    {
        isSmallDashing = true;
        moveSpeed = 30;
        yield return new WaitForSeconds(0.2f);
        moveSpeed = 4;
        isSmallDashing = false;
    }

    public void SelectDefault()
    {
        dashIncreaseValue = 5;
        playerHealth.health = 3;
        SceneManager.LoadScene("SampleScene");
    }

    public void SelectTank()
    {
        dashIncreaseValue = 5;
        playerHealth.health = 5;
        SceneManager.LoadScene("SampleScene");
    }

    public void SelectSpeed()
    {
        dashIncreaseValue = 10;
        playerHealth.health = 3;
        SceneManager.LoadScene("SampleScene");
    }
}

