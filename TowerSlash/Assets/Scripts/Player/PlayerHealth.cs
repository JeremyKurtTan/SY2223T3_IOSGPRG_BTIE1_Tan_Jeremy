using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    void Update()
    {
        if (health < 1)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void PlayerDamaged()
    {
        health -= 1;
    }
    public void PlayerHeal()
    {
        health += 1;
    }
}
