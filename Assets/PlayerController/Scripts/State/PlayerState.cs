using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    protected PlayerController _controller;

    protected PlayerState(PlayerController controller)
    {
        _controller = controller;
    }
    public virtual void Activate() { }

    public abstract void Move();
    public abstract void Attack();
    public abstract void Block();
}
