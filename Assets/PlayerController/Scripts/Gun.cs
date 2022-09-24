using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float ShotInterval = 0.2f;

    public GameObject BulletPref;
    public Transform Barrel;

    private float _timer = 0f;

    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
        {
            Instantiate(BulletPref, Barrel.position, Quaternion.identity);
            _timer = ShotInterval;
        }
    }
}
