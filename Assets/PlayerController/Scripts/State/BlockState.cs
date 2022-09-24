using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockState : PlayerState
{
    public BlockState(PlayerController controller)
        : base(controller) { }

    public override void Activate()
    {
        var enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        var look = (_controller.transform.position - enemy.position) * -1f;
        look.y = 0;

        _controller.transform.rotation = Quaternion.LookRotation(look);
    }

    public override void Move() { }

    public override void Attack() { }

    public override void Block() { }
}
