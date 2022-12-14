using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour, IBullet
{
    public float speed = 1f;
    public Rigidbody rb;
    [SerializeField]
    int bulletDamage = 4;

    public void SetDirection()
    {
        var _target = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized;
        var dir = new Vector3(_target.x, 0, _target.z).normalized;
        transform.rotation = Quaternion.LookRotation(dir);

    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) return;
        collision.gameObject.GetComponent<IDamagable>()?.SetDamage(bulletDamage);
        Destroy(gameObject);
    }
}
