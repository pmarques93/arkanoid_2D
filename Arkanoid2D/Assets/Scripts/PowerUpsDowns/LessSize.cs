using System.Collections;
using System.Collections.Generic;
using UnityEngine;

sealed public class LessSize : PowerUpBase
{
    public LessSize()
    {
        base.Type = PowerUpType.lessSize;
    }

    protected override void PickUpAbility(Player player)
    {
        if (player.transform.localScale.x > 0.6f)
            player.transform.localScale = new Vector3(player.transform.localScale.x * 0.8f, player.transform.localScale.y, player.transform.localScale.z);
        PickAndDestroy();
    }
}
