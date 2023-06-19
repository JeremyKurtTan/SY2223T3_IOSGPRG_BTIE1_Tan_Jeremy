using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManage : MonoBehaviour
{
    public int points = 0;
    Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    void Update()
    {
        score.text = "Score: " + points;

        if(DestroyArrow.destroyed == true)
        {
            points += 10;
        }
    }
}
