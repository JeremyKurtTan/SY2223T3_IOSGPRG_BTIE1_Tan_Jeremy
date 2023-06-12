using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashButton : MonoBehaviour
{
    public Transform player;
    public void DoDash()
    {
        if(PlayerController.currentDashBar != 100)
        {
            return;
        }
        else
        {
            PlayerController.isDashing = true;
            StartCoroutine(DashPlayer());
        }
    }

    IEnumerator DashPlayer()
    {
        PlayerController.moveSpeed = 30;
        yield return new WaitForSeconds(3);
        PlayerController.moveSpeed = 4;
        PlayerController.isDashing = false;
    }
}
