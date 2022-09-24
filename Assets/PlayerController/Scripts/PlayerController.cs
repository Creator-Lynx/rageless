using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamagable
{
    public float MoveSpeed = 1f;
    public int health = 100;

    [HideInInspector] public Animator animator;
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public PlayerInput input;
    public GameObject pistol;

    private PlayerState _curState;

    private PlayerState _idleState;
    private PlayerState _attackState;
    private PlayerState _blockState;
    private PlayerState _shootingState;
    private PlayerState _dashState;

    private PlayerState _damagedState;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        _idleState = new IdleState(this);
        _attackState = new AttackState(this);
        _blockState = new BlockState(this);
        _shootingState = new ShootingState(this);
        _dashState = new DashState(this);
        _damagedState = new DamagedState(this);
        SetState(0);
    }

    public void SetState(int state)
    {
        switch(state)
        {
            case 0:
                _curState = _idleState;                
                break;

            case 1:
                _curState = _attackState;
                break;

            case 2:
                _curState = _blockState;
                break;

            case 3:
                _curState = _shootingState;
                break;

            case 4:
                _curState = _dashState;
                break;

            case 99:
                _curState = _damagedState;
                break;
        }

        _curState.Activate();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SetDamage(1);
        }

        if (Input.GetMouseButtonDown(0))
        {
            _curState.Attack();
        }

        _curState.Shooting(Input.GetMouseButton(1));

        if (Input.GetKeyDown(KeyCode.F))
        {
            _curState.Block();
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _curState.Dash();            
        }
    }

    private void FixedUpdate()
    {
        _curState.Move();
        _curState.Look();
    }

    public void SetDamage(int dmg)
    {
        _curState.Damage(dmg);
    }
}
