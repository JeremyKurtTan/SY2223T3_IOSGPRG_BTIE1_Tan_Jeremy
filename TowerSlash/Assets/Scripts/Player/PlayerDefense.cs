using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDefense : MonoBehaviour
{
    public static int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {

        if (health < 1)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("SampleScene");
        }
    }
}
