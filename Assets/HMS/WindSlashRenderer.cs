using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSlashRenderer : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lineRenderer;
    float moveDist = 9.3f;
    private void Awake()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
    }

    private void Update()
    {
        Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = (target - (Vector2)transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, moveDist);
        if(hit)
        {
            Play(transform.position, hit.point);
        }
        else
        {
            Play(transform.position, dir * moveDist + (Vector2)transform.position);
        }
    }

    public void Play(Vector2 from, Vector2 to)
    {
        lineRenderer.enabled = true;

        lineRenderer.SetPosition(0, from);
        lineRenderer.SetPosition(1, to);
    }
}
