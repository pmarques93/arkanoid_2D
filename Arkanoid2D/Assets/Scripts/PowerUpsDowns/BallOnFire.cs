using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallOnFire : PowerUpBase
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
                ball.GetComponent<Ball>().BallOnFire = true;
            }
        }
        
        PickAndDestroy();
    }
}
