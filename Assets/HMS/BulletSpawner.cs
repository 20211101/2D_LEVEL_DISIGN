using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject straitBullet;
    public float startTime = 0f;
    public float coolTime = 1f;
    public float speed = 4;
    public float bulletLifetime = 10f;
    private void Start()
    {
        StartCoroutine(nameof(BulletSpawning));
    }

    IEnumerator BulletSpawning()
    {
        yield return new WaitForSeconds(startTime);

        while (true)
        {
            GameObject bullet = Instantiate(straitBullet, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
            bullet.GetComponent<StraitBullet>().Setting(bulletLifetime);
            yield return new WaitForSeconds(coolTime);
        }
    }
}
