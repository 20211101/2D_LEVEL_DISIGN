using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure_1 : MonoBehaviour
{
    public PitControll_1 pit;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            pit.StartHazard();
            Destroy(gameObject);
        }
    }
}
