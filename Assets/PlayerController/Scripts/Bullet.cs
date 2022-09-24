using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody rb;

    private void Start()
    {
        var _target = FindObjectOfType<PlayerInput>().GetDirection();
        var dir = new Vector3(_target.x, 0, _target.y).normalized;
        transform.rotation = Quaternion.LookRotation(dir);

    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
