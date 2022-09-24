using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : PlayerState
{
    private bool _dashed = false;

    public DashState(PlayerController controller)
        : base(controller) { }

    public override void Activate()
    {
        _dashed = false;
    }

    public override void Move() 
    {
        if (!_dashed)
        {
            var _target = _controller.input.GetDirection();
            var dir = new Vector3(_target.x, 0, _target.y).normalized;
            _controller.transform.rotation = Quaternion.LookRotation(dir);

            _controller.rb.MovePosition(_controller.transform.position + dir * _controller.input.GetRadius());
            _dashed = true;
        }
    }

    public override void Look() { }

    public override void Attack() { }

    public override void Block() { }

    public override void Dash() { }

    //public override bool CanBeDamaged => false;
}
