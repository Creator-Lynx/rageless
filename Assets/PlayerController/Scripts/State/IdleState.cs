using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{
    protected Vector3 moveDir;

    public IdleState(PlayerController controller)
        : base(controller) { }

    public override void Move()
    {
        var hor = Input.GetAxisRaw("Horizontal");
        var vert = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(hor, 0, vert).normalized;
        _controller.animator.SetFloat("Velocity", moveDir.magnitude);

        _controller.rb.MovePosition(_controller.transform.position + moveDir * _controller.MoveSpeed * Time.deltaTime);
    }

    public override void Look()
    {
        if (moveDir.magnitude > 0)
        {
            var _look = Quaternion.LookRotation(moveDir);
            _controller.transform.rotation = Quaternion.Lerp(_controller.transform.rotation, _look, 0.6f);
        }

    }

    public override void Attack()
    {
        _controller.SetState(1);
        _controller.animator.SetTrigger("NextAttack");
    }

    public override void Block()
    {
        _controller.SetState(2);
        _controller.animator.SetTrigger("Block");
    }

    public override void Shooting(bool isShooting)
    {
        _controller.animator.SetBool("IsShooting", isShooting);
        if (isShooting)
        {
            _controller.SetState(3);
        }
    }

    public override void Dash()
    {
        _controller.animator.SetTrigger("Dash");
        _controller.SetState(4);
    }
}
