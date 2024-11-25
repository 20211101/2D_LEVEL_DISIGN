using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraitBullet : MonoBehaviour
{
    public void Setting(float lifeTime = 10)
    {
        Destroy(gameObject, lifeTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Destroy(gameObject, 0.1f);
    }
}
