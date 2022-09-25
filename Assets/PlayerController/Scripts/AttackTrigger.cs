using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    private IDamagable target = null;

    private void OnTriggerEnter(Collider other)
    {
        var targ = other.GetComponent<IDamagable>();
        if(targ != null)
        {
            target = targ;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var targ = other.GetComponent<IDamagable>();
        if (targ != null && targ == target)
        {
            target = null;
        }
    }

    public void Attack()
    {        
        if(target != null && !target.Equals(null))
        {
            target.SetDamage(10);
        }
    }
}
