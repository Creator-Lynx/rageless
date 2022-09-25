using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPlayerState_Boss : BossState
{
    private NavMeshAgent agent;

    public MoveToPlayerState_Boss(BossStateMachine controller)
        : base(controller) { }

    public override void Activate()
    {
        //agent.isStopped = false;
        _controller.playerReached = false;
        agent = _controller.GetComponent<NavMeshAgent>();
    }

    public override void Attack() { }

    public override void Block() { }

    public override void Dash() { }

    public override void Look()
    {
        var enemy = _controller.Player.transform;
        var look = (_controller.transform.position - enemy.position) * -1f;
        look.y = 0;

        _controller.transform.rotation = Quaternion.LookRotation(look);
    }

    public override void Move()
    {
        _controller.animator.SetBool("Moving", true);

        agent.SetDestination(_controller.Player.transform.position);
        var dist = Vector3.Distance(_controller.transform.position, _controller.Player.transform.position);

        if (dist <= agent.stoppingDistance)
        {     
            //agent.isStopped = true;
            _controller.SetState(0);
            _controller.playerReached = true;
            return;
        }
    }

    public override void Shooting(bool isShooting) { }
}
