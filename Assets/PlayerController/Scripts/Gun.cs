using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float ShotInterval = 0.2f;

    public GameObject BulletPref;
    public Transform Barrel;

    private float _timer = 0f;

    void FixedUpdate()
    {
        _timer -= Time.fixedDeltaTime;
        if (_timer <= 0f)
        {
            Instantiate(BulletPref, Barrel.position, Quaternion.identity).GetComponent<IBullet>().SetDirection();
            _timer = ShotInterval;
        }
    }
}
