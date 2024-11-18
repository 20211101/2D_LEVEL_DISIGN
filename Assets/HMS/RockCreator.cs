using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCreator : MonoBehaviour
{
    [SerializeField]
    public GameObject Rock;
    public float delay = 3;
    private IEnumerator Start()
    {
        while(true)
        {
            Instantiate(Rock, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
    }
}
