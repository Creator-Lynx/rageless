using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingState : IdleState
{
    public ShootingState(PlayerController controller)
        : base(controller) { }

    public override void Move()
    {
        base.Move();
        _controller.animator.SetFloat("Velocity", 0);
    }

    public override void Look()
    {
        var _target = _controller.input.GetDirection();
        var dir = new Vector3(_target.x, 0, _target.y).normalized;
        _controller.transform.rotation = Quaternion.LookRotation(dir);
    }

    public override void Shooting(bool isShooting)
    {
        _controller.animator.SetBool("IsShooting", isShooting);
        if (!isShooting)
        {
            _controller.SetState(0);
        }
    }
}
