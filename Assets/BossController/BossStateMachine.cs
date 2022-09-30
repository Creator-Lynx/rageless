using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BossStateMachine : MonoBehaviour, IObjectWithStates, IDamagable
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

    private BossState _deadState;

    public bool isDead = false;

    public int health = 90, maxHealth = 90;
    public UnityEvent<float> OnHpChanged;

    private void Awake()
    {
        idleState = new IdleState_Boss(this);
        moveToPlayerState = new MoveToPlayerState_Boss(this);
        attackState = new AttackState_Boss(this);
        _deadState = new DeadState_Boss(this);
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
            case -1:
                curState = _deadState;
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

    public void InvokeStateAttack(int attackNumber = 0)
    {
        curState.Attack(attackNumber);
    }

    public void Attack(int attackNumber)
    {
        animator.SetBool("IsAttaking", false);
        int dmg;
        switch (attackNumber)
        {
            default:
                dmg = 10;
                break;
            case 1:
                dmg = 20;
                break;
            case 2:
                dmg = 30;
                break;
        }
        attackTrigger.Attack(dmg);
    }

    public GameObject GetPistol()
    {
        return pistol;
    }
    public void StartCor()
    {
        StartCoroutine(SetAttackState());
    }
    IEnumerator SetAttackState()
    {
        yield return new WaitForSeconds(0.2f);
        SetState(2);
        playerReached = true;

    }

    public void SetDamage(int dmg)
    {
        curState.Damage(dmg);
        if (health < 10)
        {
            GetComponent<BossController>().fase = 1;
            health = maxHealth;
            OnHpChanged.Invoke(1);
        }

    }
}
