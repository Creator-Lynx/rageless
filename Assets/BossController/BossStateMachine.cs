using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateMachine : MonoBehaviour, IObjectWithStates
{
    public GameObject Player;
    [HideInInspector] public bool playerReached = false;
    public Animator animator;
    public AttackTrigger attackTrigger;
    public bool isShooting = false;
    public GameObject pistol;

    private BossState curState = null;

    private BossState idleState;
    private BossState moveToPlayerState;    
    private BossState attackState;

    private void Start()
    {
        idleState = new IdleState_Boss(this);
        moveToPlayerState = new MoveToPlayerState_Boss(this);        
        attackState = new AttackState_Boss(this);
    }

    public void SetState(int state)
    {
        switch (state)
        {
            case 0:
                curState = idleState;
                break;

            case 1:
                curState = moveToPlayerState;
                break;

            case 2:
                curState = attackState;
                break;
        }

        curState.Activate();
    }

    private void Update()
    {        
        curState.Move();
        curState.Look();
        curState.Shooting(isShooting);
    }

    public void InvokeStateAttack()
    {
        curState.Attack();
    }

    public void Attack()
    {
        attackTrigger.Attack();
    }

    public GameObject GetPistol()
    {
        return pistol;
    }
}
