using System.Collections;
using System.Collections.Generic;
using UnityEngine;

sealed public class Guns : PowerUpBase
{
    protected override void PickUpAbility(Player player)
    {
        player.HasGuns = true;
        PickAndDestroy();
    }
}

