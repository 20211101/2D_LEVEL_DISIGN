using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPlatform : MonoBehaviour
{
    public BoxCollider2D collider;
    public Rigidbody2D renderObj;
    public float brokeTimeSetting = 0.5f;
    public float restoreTimeSetting = 2f;
    bool startBroke = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("¥Í¿Ω");
        if (startBroke) return;
        if(collision.gameObject.CompareTag("Player"))
        {
            startBroke = true;
            StartCoroutine("Broke");
        }
    }

    IEnumerator Broke()
    {
        Transform renderT = renderObj.transform;
        float brokeTime = 0;
        float offset = 0.1f;
        while(brokeTime < brokeTimeSetting)
        {
            offset = -offset;
            brokeTime += Time.deltaTime;
            renderT.position = renderT.position + new Vector3(offset,0, 0);
            yield return null;
        }

        collider.enabled = false;
        renderObj.gravityScale = 3;

        StartCoroutine(nameof(Restore));
    }

    IEnumerator Restore()
    {
        yield return new WaitForSeconds(restoreTimeSetting/2);
        renderObj.gameObject.SetActive(false);
        yield return new WaitForSeconds(restoreTimeSetting/2);
        renderObj.gameObject.SetActive(true);
        collider.enabled = true;
        renderObj.gravityScale = 0;
        renderObj.velocity = Vector3.zero;
        renderObj.transform.position = transform.position;
        startBroke = false;
    }
}
