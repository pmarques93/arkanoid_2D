using System.Collections;
using System.Collections.Generic;
using UnityEngine;

sealed public class MoreSize : PowerUpBase
{
    protected override void PickUpAbility(Player player)
    {
        if (player.transform.localScale.x < 4f)
            player.transform.localScale = new Vector3(player.transform.localScale.x * 1.2f, player.transform.localScale.y, player.transform.localScale.z);
        PickAndDestroy();
    }
}

