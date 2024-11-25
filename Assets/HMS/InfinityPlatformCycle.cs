using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

[System.Serializable]


public class InfinityPlatformCycle : MonoBehaviour
{
    public bool useX = false;
    public bool useY = false;
    public Vector2 dir = Vector2.up;
    public Transform top;
    public Transform bottom;
    public Transform right;
    public Transform left;
    public Rigidbody2D[] childT;

    private void Update()
    {
        if(useY)
        {
            for (int i = 0; i < childT.Length; i++ )
            {
                if (dir.y == 1 && childT[i].position.y > top.position.y)
                    childT[i].transform.position = bottom.position;
                else if (dir.y == -1 && childT[i].transform.position.y < bottom.position.y)
                    childT[i].transform.position = top.position;
            }
        }
        if(useX)
        {
            for (int i = 0; i < childT.Length; i++ )
            {
                if (dir.x == 1 && childT[i].position.x > right.position.x)
                    childT[i].position = left.position;
                else if (dir.x == -1 && childT[i].position.x < left.position.x)
                    childT[i].position = right.position;
            }
        }
    }
}
