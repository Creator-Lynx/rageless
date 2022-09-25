using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedState : PlayerState
{
    public DamagedState(PlayerController controller)
        : base(controller) { }    

    public override void Look() { }

    public override void Attack() { }

    public override void Block() { }

    public override void Dash() { }

    public override bool CanBeDamaged => false;
}
