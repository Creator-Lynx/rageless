using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody rb;

    private void Start()
    {
        var _target = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized;
        var dir = new Vector3(_target.x, 0, _target.z).normalized;
        transform.rotation = Quaternion.LookRotation(dir);

    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(gameObject);
    }
}
