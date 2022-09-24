using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 1f;

    [HideInInspector] public Animator animator;
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public PlayerInput input;

    private PlayerState _curState;

    private PlayerState _idleState;
    private PlayerState _attackState;
    private PlayerState _blockState;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        _idleState = new IdleState(this);
        _attackState = new AttackState(this);
        _blockState = new BlockState(this);
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
        }

        _curState.Activate();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _curState.Attack();
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            _curState.Block();
        }
    }

    private void FixedUpdate()
    {
        _curState.Move();
    }
}
