using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stimpack : MonoBehaviour
{
    [SerializeField] private Inventory playerInventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInventory = collision.gameObject.GetComponent<Inventory>();
        if (playerInventory != null)
        {
            if (playerInventory.Inventory_StimpackAmount >= 3)
                return;

            playerInventory.Inventory_StimpackAmount += 1;
            playerInventory.HealInfo();
            Destroy(gameObject);
        }
    }
}
