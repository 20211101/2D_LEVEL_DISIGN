using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraitBullet : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 10);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Destroy(gameObject, 0.1f);
    }
}
