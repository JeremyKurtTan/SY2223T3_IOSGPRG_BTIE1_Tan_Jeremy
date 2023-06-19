using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerController playerController;
    public  PlayerHealth playerHealth;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GreenArrow")
        {
            if (collision.gameObject.name == "DownArrowGreen(Clone)" || playerController.CurrentDirection == Direction.All)
            {
                if (playerController.CurrentDirection == Direction.isDown)
                {
                    ResetDir();
                }
                else if (playerController.CurrentDirection != Direction.isDown && playerController.CurrentDirection != Direction.Idle)
                {
                    WrongDirection();
                }
            }
            if (collision.gameObject.name == "LeftArrowGreen(Clone)" || playerController.CurrentDirection == Direction.All)
            {
                if (playerController.CurrentDirection == Direction.isLeft)
                {
                    ResetDir();
                }
                else if (playerController.CurrentDirection != Direction.isLeft && playerController.CurrentDirection != Direction.Idle)
                {
                    WrongDirection();
                }
            }
            if (collision.gameObject.name == "RightArrowGreen(Clone)" || playerController.CurrentDirection == Direction.All)
            {
                if (playerController.CurrentDirection == Direction.isRight)
                {
                    ResetDir();
                }
                else if (playerController.CurrentDirection != Direction.isRight && playerController.CurrentDirection != Direction.Idle)
                {
                    WrongDirection();
                }
            }
            if (collision.gameObject.name == "UpArrowGreen(Clone)" || playerController.CurrentDirection == Direction.All)
            {
                if (playerController.CurrentDirection == Direction.isUp)
                {
                    ResetDir();
                }
                else if (playerController.CurrentDirection != Direction.isUp && playerController.CurrentDirection != Direction.Idle)
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
                if (playerController.CurrentDirection == Direction.isUp || playerController.CurrentDirection == Direction.All)
                {
                    ResetDir();
                }
                else if (playerController.CurrentDirection != Direction.isUp && playerController.CurrentDirection != Direction.Idle)
                {
                    WrongDirection();
                }
            }
            if (collision.gameObject.name == "LeftArrowRed(Clone)")
            {
                if (playerController.CurrentDirection == Direction.isRight || playerController.CurrentDirection == Direction.All)
                {
                    ResetDir();
                }
                else if (playerController.CurrentDirection != Direction.isRight && playerController.CurrentDirection != Direction.Idle)
                {
                    WrongDirection();
                }
            }
            if (collision.gameObject.name == "RightArrowRed(Clone)")
            {
                if (playerController.CurrentDirection == Direction.isLeft || playerController.CurrentDirection == Direction.All)
                {
                    ResetDir();
                }
                else if (playerController.CurrentDirection != Direction.isLeft && playerController.CurrentDirection != Direction.Idle)
                {
                    WrongDirection();
                }
            }
            if (collision.gameObject.name == "UpArrowRed(Clone)")
            {
                if (playerController.CurrentDirection == Direction.isDown || playerController.CurrentDirection == Direction.All)
                {
                    ResetDir();
                }
                else if (playerController.CurrentDirection != Direction.isDown && playerController.CurrentDirection != Direction.Idle)
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
                if (playerController.CurrentDirection == Direction.isDown || playerController.CurrentDirection == Direction.All)
                {
                    ResetDir();
                }
                else if (playerController.CurrentDirection != Direction.isDown && playerController.CurrentDirection != Direction.Idle)
                {
                    WrongDirection();
                }
            }
            if (collision.gameObject.name == "LeftArrowRotate(Clone)")
            {
                if (playerController.CurrentDirection == Direction.isLeft || playerController.CurrentDirection == Direction.All)
                {
                    ResetDir();
                }
                else if (playerController.CurrentDirection != Direction.isLeft && playerController.CurrentDirection != Direction.Idle)
                {
                    WrongDirection();
                }
            }
            if (collision.gameObject.name == "RightArrowRotate(Clone)")
            {
                if (playerController.CurrentDirection == Direction.isRight || playerController.CurrentDirection == Direction.All)
                {
                    ResetDir();
                }
                else if (playerController.CurrentDirection != Direction.isRight && playerController.CurrentDirection != Direction.Idle)
                {
                    WrongDirection();
                }
            }
            if (collision.gameObject.name == "UpArrowRotate(Clone)")
            {
                if (playerController.CurrentDirection == Direction.isUp || playerController.CurrentDirection == Direction.All)
                {
                    ResetDir();
                }
                else if (playerController.CurrentDirection != Direction.isUp && playerController.CurrentDirection != Direction.Idle)
                {
                    WrongDirection();
                }
            }
        }
    }
    void WrongDirection()
    {
        playerHealth.health -= 1;
        playerController.CurrentDirection = Direction.Idle;
    }

    void ResetDir()
    {
        DestroyArrow.destroyed = true;
        playerController.currentDashBar += playerController.dashIncreaseValue;
        playerController.dashMeterBar.SetDashMeter(playerController.currentDashBar);
        playerController.CurrentDirection = Direction.Idle;
    }
}
