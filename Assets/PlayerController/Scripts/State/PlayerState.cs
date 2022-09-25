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

    public virtual void Move()
    {
        _controller.animator.SetFloat("Velocity", 0);
    }
    public abstract void Look();
    public abstract void Attack();
    public abstract void Block();
    public virtual void Shooting(bool isShooting)
    {
        _controller.animator.SetBool("IsShooting", false);
    }
    public abstract void Dash();

    public virtual bool CanBeDamaged => true;
    public void Damage(int dmg)
    {
        if (CanBeDamaged)
        {
            _controller.health -= dmg;

            if (_controller.health > 0)
            {
                _controller.SetState(99);
                _controller.animator.SetTrigger("Damaged");
            }
            else
            {
                _controller.SetState(-1);
                _controller.animator.SetTrigger("Death");
            }
        }
    }
}
