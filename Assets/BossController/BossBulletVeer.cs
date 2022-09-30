using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletVeer : MonoBehaviour, IBullet
{
    public float speed = 1f;
    public Rigidbody rb;
    [SerializeField]
    int bulletDamage = 4;

    public void SetDirection()
    {
        //var _target = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized;


    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) return;
        IDamagable a = collision.gameObject.GetComponent<IDamagable>();
        if (a != null)
        {
            collision.gameObject.GetComponent<IDamagable>()?.SetDamage(bulletDamage);
            Destroy(gameObject);
        }

    }
}
