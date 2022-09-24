using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{
    private Quaternion _look = Quaternion.Euler(0, 0, 0);

    public IdleState(PlayerController controller)
        : base(controller) { }

    public override void Move()
    {
        var hor = Input.GetAxisRaw("Horizontal");
        var vert = Input.GetAxisRaw("Vertical");

        var moveDir = new Vector3(hor, 0, vert).normalized;
        _controller.animator.SetFloat("Velocity", moveDir.magnitude);

        if (moveDir.magnitude > 0)
        {
            _look = Quaternion.LookRotation(moveDir);
            _controller.transform.rotation = Quaternion.Lerp(_controller.transform.rotation, _look, 0.6f);
        }       

        _controller.rb.MovePosition(_controller.transform.position + moveDir * _controller.MoveSpeed * Time.deltaTime);
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
}
