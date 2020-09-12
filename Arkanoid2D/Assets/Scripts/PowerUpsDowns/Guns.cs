using System.Collections;
using System.Collections.Generic;
using UnityEngine;

sealed public class Guns : PowerUpBase
{
    public Guns()
    {
        base.Type = PowerUpType.guns;
    }

    protected override void PickUpAbility(Player player)
    {
        player.HasGuns = true;
        PickAndDestroy();
    }
}

