using System;
using UnityEngine;

public class VeerShotingState_Boss : BossState
{
    public VeerShotingState_Boss(BossStateMachine controller)
        : base(controller) { }

    public override void Attack(int attackNumber)
    {
    }

    public override void Activate()
    {
        _controller.animator.SetBool("Moving", false);
        _controller.GetPistol().GetComponent<Gun>().isStandartBullet = false;
        _controller.GetPistol().GetComponent<Gun>().ShotInterval = 0.07f;
    }
    public override void Block() { }

    public override void Dash() { }
    float timer = 0f;
    bool forward = true;
    public override void Look()
    {
        timer += Time.deltaTime;
        float angle = forward ?
        Mathf.Lerp(-_controller.ShootingAngle, _controller.ShootingAngle, timer / _controller.ShootingPeriod) :
        Mathf.Lerp(_controller.ShootingAngle, -_controller.ShootingAngle, timer / _controller.ShootingPeriod);
        angle += 180;
        if (timer > _controller.ShootingPeriod)
        {
            timer = 0;
            forward = !forward;
        }
        _controller.transform.rotation = Quaternion.Euler(0, angle, 0f);
    }

    public override void Move()
    {
        _controller.animator.SetBool("Moving", false);
    }

    public override void Shooting(bool isShooting)
    {
        _controller.animator.SetBool("IsShooting", true);
    }
}
