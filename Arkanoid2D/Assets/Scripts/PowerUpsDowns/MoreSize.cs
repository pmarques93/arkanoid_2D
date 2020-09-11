﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

sealed public class MoreSize : PowerUpBase
{
    public MoreSize()
    {
        base.Type = PowerUpType.moreSize;
    }

    protected override void PickUpAbility(Player player)
    {
        if (player.transform.localScale.x < 5f)
            player.transform.localScale = new Vector3(player.transform.localScale.x * 1.2f, player.transform.localScale.y, player.transform.localScale.z);
        PickAndDestroy();
    }
}
