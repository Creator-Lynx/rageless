using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour, IDamagable, IObjectWithStates
{
    public float MoveSpeed = 1f;
    public int health = 90, maxHealth = 90;
    public float dashRange = 4f, dashCoolDown = 2f;

    public UnityEvent<float> OnHpChanged;

    public Animator animator;
    [HideInInspector] public Rigidbody rb;
    public PlayerInput input;
    public GameObject pistol;
    public AttackTrigger attackTrigger;

    private PlayerState _curState;

    private PlayerState _idleState;
    private PlayerState _attackState;
    private PlayerState _blockState;
    private PlayerState _shootingState;
    private PlayerState _dashState;

    private PlayerState _damagedState;
    private PlayerState _deadState;

    private void Start()
    {
        //animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        _idleState = new IdleState(this);
        _attackState = new AttackState(this);
        _blockState = new BlockState(this);
        _shootingState = new ShootingState(this);
        _dashState = new DashState(this);
        _damagedState = new DamagedState(this);
        _deadState = new DeadState(this);
        SetState(0);
    }

    public void SetState(int state)
    {
        switch (state)
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
            case -1:
                _curState = _deadState;
                break;
        }

        _curState.Activate();
    }

    float dashTimer = 3f;
    private void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            _curState.Attack();
        }

        _curState.Shooting(Input.GetMouseButton(1));

        if (Input.GetKeyDown(KeyCode.F))
        {
            _curState.Block();
        }
        dashTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && dashTimer > dashCoolDown)
        {
            dashTimer = 0;
            _curState.Dash();
        }
    }

    public void Attack(int attackNumber)
    {
        int dmg;
        switch (attackNumber)
        {
            default:
                dmg = 10;
                break;
            case 1:
                dmg = 15;
                break;
            case 2:
                dmg = 30;
                break;
        }
        attackTrigger.Attack(dmg);
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

    public GameObject GetPistol()
    {
        return pistol;
    }
}
