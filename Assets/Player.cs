using Gamekit2D;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player _instance;
    public static Player instance { get => _instance; private set { } }
    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);
    }
    PlayerCharacter p;
    internal void StopTime(PlayerCharacter m_MonoBehaviour)
    {
        p = m_MonoBehaviour;
        startPos = transform.position;
        isCheckDist = true;
        p.GetComponent<Damageable>().damagable = false;
    }
    Vector3 startPos;
    bool isCheckDist = false;
    float moveDist = 8f;
    void Update()
    {
        if (isCheckDist == true)
        {
            if((transform.position - startPos).sqrMagnitude > moveDist * moveDist)
            {
                p.GetComponent<Damageable>().damagable = true;
                p.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                p.SetMoveVector(Vector2.zero);
                isCheckDist = false;
                //StartCoroutine(nameof(DamageControl));
            }
        }
    }

    public bool damagable = true;
    IEnumerator DamageControl()
    {
        damagable = false;
        yield return new WaitForSeconds(0.5f);
        p.GetComponent<Damageable>().damagable = true;
        damagable = true;
    }

}
