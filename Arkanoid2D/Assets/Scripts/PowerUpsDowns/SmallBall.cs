using System.Collections;
using System.Collections.Generic;
using UnityEngine;

sealed public class SmallBall : PowerUpBase
{
    GameObject[] balls;

    private void Start()
    {
        balls = GameObject.FindGameObjectsWithTag("Ball");
    }

    protected override void PickUpAbility(Player player)
    {
        foreach (GameObject ball in balls)
        {
            if (ball != null)
            {
                if (ball.GetComponent<Ball>().transform.localScale.x > 0.5f)
                {
                    ball.GetComponent<Ball>().transform.localScale *= 0.5f;
                }
            }
        }

        PickAndDestroy();
    } 
}
