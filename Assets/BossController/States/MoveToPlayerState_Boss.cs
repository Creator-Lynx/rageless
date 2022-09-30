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

    public override void Attack(int attackNumber)
    {
        // _controller.SetState(2);
        // _controller.animator.SetTrigger("Attack" + attackNumber);
    }

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
        //_controller.animator.SetBool("Moving", true);

        //agent.SetDestination(_controller.Player.transform.position);
        //var dist = Vector3.Distance(_controller.transform.position, _controller.Player.transform.position);

        //if (dist <= agent.stoppingDistance)
        //{     
        //    //agent.isStopped = true;
        //    _controller.SetState(0);
        //    _controller.playerReached = true;
        //    return;
        //}
        var dir = _controller.Player.transform.position - _controller.transform.position;
        _controller.transform.position = Vector3.Lerp(
            _controller.transform.position,
             _controller.Player.transform.position - (dir.normalized * 1.7f / 2), .78f);

        var dist = Vector3.Distance(_controller.transform.position, _controller.Player.transform.position);
        if (dist <= 1.7f)
        {
            //_controller.SetState(0);
            //_controller.playerReached = true;
            //return;
            _controller.StartCor();
        }
    }


    public override void Shooting(bool isShooting) { }
}
