using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectWithStates
{
    void SetState(int state);
    void Attack();
    GameObject GetPistol();
}
