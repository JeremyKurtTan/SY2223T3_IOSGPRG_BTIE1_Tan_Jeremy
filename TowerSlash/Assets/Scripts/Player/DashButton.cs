using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashButton : MonoBehaviour
{
    public PlayerController playerController;
    GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }
    public void DoDash()
    {
        if (playerController.currentDashBar != 100)
        {
            return;
        }
        else
        { 
            StartCoroutine(DashPlayer());
        }
    }

    IEnumerator DashPlayer()
    {
        playerController.isDashing = true;
        playerController.isSmallDashing = true;
        playerController.moveSpeed = 30;
        yield return new WaitForSeconds(3);
        playerController.moveSpeed = 4;
        playerController.isDashing = false;
        playerController.isSmallDashing = false;
    }
}
