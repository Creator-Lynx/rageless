using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restrictions : MonoBehaviour
{
    public Transform Player;
    public float radius = 10f;

    private void LateUpdate()
    {
        if(Player.position.magnitude > radius)
        {
            Player.position = Player.position.normalized * radius;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
