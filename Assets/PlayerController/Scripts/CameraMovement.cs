using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraMovement : MonoBehaviour
{
    public Transform Player;
    public float Y;
    public Vector3 Offset;

    private void Update()
    {
        SetCam();
    }
   
    private void SetCam()
    {
        var newPos = new Vector3(Player.position.x + Offset.x, Y, Player.position.z + Offset.z);
        transform.position = Vector3.Lerp(transform.position, newPos, 0.8f);

        transform.LookAt(Player);
    }
}
