using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : PlayerState
{
    private Vector2 _target;

    public AttackState(PlayerController controller)
        : base(controller) { }

    public override void Activate()
    {
        _target = _controller.input.GetDirection();
    }

    public override void Move() { }

    public override void Look() 
    {
        var dir = new Vector3(_target.x, 0, _target.y).normalized;
        _controller.transform.rotation = Quaternion.LookRotation(dir);
    }

    public override void Attack() { }

    public override void Block() { }

    public override void Dash() { }
}
