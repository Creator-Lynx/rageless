using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownSwordCheat : MonoBehaviour, ICheatExecutable
{
    [SerializeField]
    MeshRenderer sword;
    [SerializeField]
    Material brown;
    public void Execute()
    {
        sword.material = brown;
    }
}
