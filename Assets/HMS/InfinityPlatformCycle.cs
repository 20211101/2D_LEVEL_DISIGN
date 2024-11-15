using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

[System.Serializable]


public class InfinityPlatformCycle : MonoBehaviour
{
    public bool isAuto = true;
    public float speed = 4f;
    public Vector2 dir = Vector2.up;
    public Transform top;
    public Transform bottom;
    public Rigidbody2D[] childT;

    private void FixedUpdate()
    {
        for (int i = 0; i < childT.Length; i++ )
        {
            if (dir.y == 1 && childT[i].position.y > top.position.y)
                childT[i].position = bottom.position;
            else if (dir.y == -1 && childT[i].position.y < bottom.position.y)
                childT[i].position = top.position;
        }
    }
}
