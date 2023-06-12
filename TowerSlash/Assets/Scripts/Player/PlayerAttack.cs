using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GreenArrow")
        {
            if (collision.gameObject.name == "DownArrowGreen(Clone)")
            {
                if (PlayerController.CurrentDirection == Direction.isDown || PlayerController.CurrentDirection == Direction.All)
                {
                    DestroyArrow.destroyed = true;
                    PlayerController.CurrentDirection = Direction.Idle;
                }
                else if (PlayerController.CurrentDirection != Direction.isDown && PlayerController.CurrentDirection != Direction.Idle)
                {
                    WrongDirection();
                }
            }
            if (collision.gameObject.name == "LeftArrowGreen(Clone)")
            {
                if (PlayerController.CurrentDirection == Direction.isLeft || PlayerController.CurrentDirection == Direction.All)
                {
                    DestroyArrow.destroyed = true;
                    PlayerController.CurrentDirection = Direction.Idle;
                }
                else if (PlayerController.CurrentDirection != Direction.isLeft && PlayerController.CurrentDirection != Direction.Idle)
                {
                    WrongDirection();
                }
            }
            if (collision.gameObject.name == "RightArrowGreen(Clone)")
            {
                if (PlayerController.CurrentDirection == Direction.isRight || PlayerController.CurrentDirection == Direction.All)
                {
                    DestroyArrow.destroyed = true;
                    PlayerController.CurrentDirection = Direction.Idle;
                }
                else if (PlayerController.CurrentDirection != Direction.isRight && PlayerController.CurrentDirection != Direction.Idle)
                {
                    WrongDirection();
                }
            }
            if (collision.gameObject.name == "UpArrowGreen(Clone)")
            {
                if (PlayerController.CurrentDirection == Direction.isUp || PlayerController.CurrentDirection == Direction.All)
                {
                    DestroyArrow.destroyed = true;
                    PlayerController.CurrentDirection = Direction.Idle;
                }
                else if (PlayerController.CurrentDirection != Direction.isUp && PlayerController.CurrentDirection != Direction.Idle)
                {
                    WrongDirection();
                }
            }
        }

        //---------------------------------------------------------------------
        if (collision.gameObject.tag == "RedArrow")
        {
            if (collision.gameObject.name == "DownArrowRed(Clone)")
            {
                if (PlayerController.CurrentDirection == Direction.isUp || PlayerController.CurrentDirection == Direction.All)
                {
                    DestroyArrow.destroyed = true;
                    PlayerController.CurrentDirection = Direction.Idle;
                }
                else if (PlayerController.CurrentDirection != Direction.isUp && PlayerController.CurrentDirection != Direction.Idle)
                {
                    WrongDirection();
                }
            }
            if (collision.gameObject.name == "LeftArrowRed(Clone)")
            {
                if (PlayerController.CurrentDirection == Direction.isRight || PlayerController.CurrentDirection == Direction.All)
                {
                    DestroyArrow.destroyed = true;
                    PlayerController.CurrentDirection = Direction.Idle;
                }
                else if (PlayerController.CurrentDirection != Direction.isRight && PlayerController.CurrentDirection != Direction.Idle)
                {
                    WrongDirection();
                }
            }
            if (collision.gameObject.name == "RightArrowRed(Clone)")
            {
                if (PlayerController.CurrentDirection == Direction.isLeft || PlayerController.CurrentDirection == Direction.All)
                {
                    DestroyArrow.destroyed = true;
                    PlayerController.CurrentDirection = Direction.Idle;
                }
                else if (PlayerController.CurrentDirection != Direction.isLeft && PlayerController.CurrentDirection != Direction.Idle)
                {
                    WrongDirection();
                }
            }
            if (collision.gameObject.name == "UpArrowRed(Clone)")
            {
                if (PlayerController.CurrentDirection == Direction.isDown || PlayerController.CurrentDirection == Direction.All)
                {
                    DestroyArrow.destroyed = true;
                    PlayerController.CurrentDirection = Direction.Idle;
                }
                else if (PlayerController.CurrentDirection != Direction.isDown && PlayerController.CurrentDirection != Direction.Idle)
                {
                    WrongDirection();
                }

            }
           
        }
        //---------------------------------------------------------------------
        if (collision.gameObject.tag == "RotateArrow")
        {
            if (collision.gameObject.name == "DownArrowRotate(Clone)")
            {
                if (PlayerController.CurrentDirection == Direction.isDown || PlayerController.CurrentDirection == Direction.All)
                {
                    DestroyArrow.destroyed = true;
                    PlayerController.CurrentDirection = Direction.Idle;
                }
                else if (PlayerController.CurrentDirection != Direction.isDown && PlayerController.CurrentDirection != Direction.Idle)
                {
                    WrongDirection();
                }
            }
            if (collision.gameObject.name == "LeftArrowRotate(Clone)")
            {
                if (PlayerController.CurrentDirection == Direction.isLeft || PlayerController.CurrentDirection == Direction.All)
                {
                    DestroyArrow.destroyed = true;
                    PlayerController.CurrentDirection = Direction.Idle;
                }
                else if (PlayerController.CurrentDirection != Direction.isLeft && PlayerController.CurrentDirection != Direction.Idle)
                {
                    WrongDirection();
                }
            }
            if (collision.gameObject.name == "RightArrowRotate(Clone)")
            {
                if (PlayerController.CurrentDirection == Direction.isRight || PlayerController.CurrentDirection == Direction.All)
                {
                    DestroyArrow.destroyed = true;
                    PlayerController.CurrentDirection = Direction.Idle;
                }
                else if (PlayerController.CurrentDirection != Direction.isRight && PlayerController.CurrentDirection != Direction.Idle)
                {
                    WrongDirection();
                }
            }
            if (collision.gameObject.name == "UpArrowRotate(Clone)")
            {
                if (PlayerController.CurrentDirection == Direction.isUp || PlayerController.CurrentDirection == Direction.All)
                {
                    DestroyArrow.destroyed = true;
                    PlayerController.CurrentDirection = Direction.Idle;
                }
                else if (PlayerController.CurrentDirection != Direction.isUp && PlayerController.CurrentDirection != Direction.Idle)
                {
                    WrongDirection();
                }
            }
        }
    }

    void WrongDirection()
    {
        PlayerHealth.health -= 1;
        PlayerController.CurrentDirection = Direction.Idle;
    }
}
