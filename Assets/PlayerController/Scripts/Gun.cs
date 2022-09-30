using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float ShotInterval = 0.2f;
    public bool isStandartBullet = true;
    public GameObject BulletPref;
    public GameObject BulletPref2;
    public Transform Barrel;

    private float _timer = 0f;

    void FixedUpdate()
    {
        _timer -= Time.fixedDeltaTime;
        if (_timer <= 0f)
        {
            Instantiate(isStandartBullet ? BulletPref : BulletPref2, Barrel.position, Barrel.rotation).
            GetComponent<IBullet>().SetDirection();
            _timer = ShotInterval;
        }
    }
}
