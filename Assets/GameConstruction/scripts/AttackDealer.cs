using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDealer : MonoBehaviour
{

    IObjectWithStates controller;

    private void Start()
    {
        controller = GetComponentInParent<IObjectWithStates>();
    }

    public void Attack()
    {
        controller.Attack();
    }

}
