using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState_Boss : BossState
{
    public AttackState_Boss(BossStateMachine controller)
        : base(controller) { }

    public override void Attack(int attackNumber) { }

    public override void Block() { }

    public override void Dash() { }

    public override void Look() { }

    public override void Move()
    {
        _controller.animator.SetBool("Moving", false);
    }

    public override void Shooting(bool isShooting) { }
}
