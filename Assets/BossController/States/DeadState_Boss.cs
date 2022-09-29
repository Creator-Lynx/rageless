using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState_Boss : BossState
{
    public DeadState_Boss(BossStateMachine controller)
        : base(controller) { }

    public override void Attack(int attackNumber) { }

    public override void Block() { }

    public override void Dash() { }

    public override void Look() { }

    public override void Move() { }

    public override void Shooting(bool isShooting) { }
}
