using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Transform player;
    [SerializeField] private Transform _target;
    [SerializeField] private float _radius;
    //[SerializeField] private float _deadZoneRadius;
    public float _speed = 1f;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        transform.position = player.position + Vector3.up;

        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");
        var mouseOffset = new Vector3(mouseX, 0, mouseY);

        _target.localPosition += mouseOffset * _speed;

        if (_target.localPosition.magnitude > _radius)
        {
            _target.localPosition = _target.localPosition.normalized * _radius;
        }
    }

    public Vector2 GetDirection()
    {
        return new Vector2
        {
            x = _target.localPosition.x / _radius,
            y = _target.localPosition.z / _radius
        };
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radius);
        Gizmos.DrawLine(transform.position, _target.position);

        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, _deadZoneRadius);

        //Gizmos.color = Color.white;
        //Gizmos.DrawSphere(_target.position, 0.15f);
    }
}
