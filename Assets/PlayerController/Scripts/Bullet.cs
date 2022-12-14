using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IBullet
{
    public float speed = 1f;
    public int bulleDamage = 2;
    public Rigidbody rb;

    public void SetDirection()
    {
        var _target = FindObjectOfType<PlayerInput>().GetDirection();
        var dir = new Vector3(_target.x, 0, _target.y).normalized;
        transform.rotation = Quaternion.LookRotation(dir);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) return;
        collision.gameObject.GetComponent<IDamagable>()?.SetDamage(bulleDamage);
        Destroy(gameObject);
    }
}
