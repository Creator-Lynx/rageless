using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossState
{
    protected BossStateMachine _controller;

    protected BossState(BossStateMachine controller)
    {
        _controller = controller;
    }
    public virtual void Activate()
    {
        _controller.animator.SetBool("Moving", false);
        _controller.GetPistol().GetComponent<Gun>().isStandartBullet = true;
        _controller.GetPistol().GetComponent<Gun>().ShotInterval = 0.2f;
    }

    public abstract void Move();
    public abstract void Look();
    public abstract void Attack(int attackNumber);
    public abstract void Block();
    public abstract void Shooting(bool isShooting);
    public abstract void Dash();

    public virtual bool CanBeDamaged => true;
    public void Damage(int dmg)
    {
        if (CanBeDamaged)
        {
            _controller.health -= dmg;
            _controller.OnHpChanged.Invoke((float)_controller.health / (float)(_controller.maxHealth));
            if (_controller.health > 0)
            {
                _controller.SetState(99);
                _controller.animator.SetTrigger("Damaged");
            }
            else
            {
                _controller.animator.SetTrigger("Dead");
                _controller.SetState(-1);
                _controller.isDead = true;
            }
        }
    }
}
