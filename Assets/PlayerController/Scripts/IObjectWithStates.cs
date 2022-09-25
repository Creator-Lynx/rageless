using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectWithStates
{
    void SetState(int state);
    GameObject GetPistol();
}
