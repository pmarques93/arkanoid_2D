using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBall : PowerUpBase
{
    [SerializeField] GameObject ballPrefab;

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
                GameObject ballInstanceGO = Instantiate(ballPrefab, ball.transform.position, ball.transform.rotation);
                ballInstanceGO.GetComponent<Ball>().rb.AddForce(new Vector2(ball.GetComponent<Ball>().ballSpeed, ball.GetComponent<Ball>().ballSpeed));
            }
        }
        
        PickAndDestroy();
    }
}
