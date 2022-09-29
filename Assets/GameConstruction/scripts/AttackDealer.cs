using UnityEngine;

public class AttackDealer : MonoBehaviour
{

    IObjectWithStates controller;

    private void Start()
    {
        controller = GetComponentInParent<IObjectWithStates>();
    }

    public void Attack(int attackNumber)
    {
        controller.Attack(attackNumber);
    }

}
