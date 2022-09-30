using System;
using UnityEngine;

public class ShotingState_Boss : BossState
{
    public AttackState_Boss(BossStateMachine controller)
        : base(controller) { }

    public override void Attack(int attackNumber)
    {
    }

    public override void Block() { }

    public override void Dash() { }
    float timer = 0f;
    public override void Look()
    {

        _controller.transform.rotation = Quaternion.Euler(0, 0f, 0f);
    }

    public override void Move()
    {
        _controller.animator.SetBool("Moving", false);
    }

    public override void Shooting(bool isShooting)
    {
        _controller.animator.SetBool("isShooting", false);
    }
}
