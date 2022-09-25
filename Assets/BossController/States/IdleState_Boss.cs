using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState_Boss : BossState
{
    public IdleState_Boss(BossStateMachine controller)
        : base(controller) { } 

    public override void Attack() 
    {
        _controller.SetState(2);
        _controller.animator.SetTrigger("Attack");
    }

    public override void Block() { }

    public override void Dash() { }

    public override void Look()
    {
        var enemy = _controller.Player.transform;
        var look = (_controller.transform.position - enemy.position) * -1f;
        look.y = 0;

        _controller.transform.rotation = Quaternion.LookRotation(look);
    }

    public override void Move() 
    {
        _controller.animator.SetBool("Moving", false);
    }

    public override void Shooting(bool isShooting) 
    {
        _controller.animator.SetBool("IsShooting", isShooting);
        if(isShooting)
        {
            _controller.SetState(3);
        }
    }
}
