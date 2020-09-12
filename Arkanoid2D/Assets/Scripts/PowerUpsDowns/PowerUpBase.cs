using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    // PowerUpType
    protected PowerUpType Type { get; set; }

    // What does it do
    protected abstract void PickUpAbility(Player player);

    private void Update()
    {
        if (transform.position.y < -5.5f)
        {
            Destroy(gameObject);
        }
    }

    // Action on trigger enter
    private void OnCollisionEnter2D(Collision2D hitInfo)
    {
        // Gets player
        Player player = hitInfo.transform.GetComponent<Player>();

        // Does something if there's a collision with the player
        if (player != null)
        {
            // PickUpAbility depends of which Type the Power Up is
            PickUpAbility(player);
        }
    }

    // Instantiates the pickup gameobject and destroys this gameobject
    protected virtual void PickAndDestroy()
    {
        Destroy(gameObject);
    }
}

