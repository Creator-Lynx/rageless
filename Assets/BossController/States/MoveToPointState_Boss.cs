using UnityEngine;
using UnityEngine.AI;

public class MoveToPointState_Boss : BossState
{

    float timeToDest = 3f;

    public MoveToPointState_Boss(BossStateMachine controller)
        : base(controller) { }

    public override void Activate()
    {
        _controller.playerReached = false;
        _controller.animator.SetBool("Moving", true);
        timerToDest = 0f;
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
        var look = (_controller.transform.position - _controller.targetPoint) * -1f;
        look.y = 0;

        _controller.transform.rotation = Quaternion.LookRotation(look);
    }
    float timerToDest = 0f;
    public override void Move()
    {


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
        timerToDest += Time.deltaTime;
        _controller.transform.position = Vector3.Lerp(
            _controller.transform.position,
             _controller.targetPoint, timerToDest / timeToDest);

        if (timerToDest >= timeToDest)
        {
            _controller.SetState(0);
            _controller.playerReached = true;
            _controller.animator.SetBool("Moving", false);
            return;
            //_controller.StartCor();
        }
    }


    public override void Shooting(bool isShooting) { }
}
