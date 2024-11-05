using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSpikeBox : MonoBehaviour
{
    public float rotatePeriod = 1;
    private void Start()
    {
        StartCoroutine(nameof(RotateCoroutine));
    }

    IEnumerator RotateCoroutine()
    {
        while(true)
        {
            transform.rotation = Quaternion.Euler(0, 0, (transform.rotation.eulerAngles.z + 90) % 360);
            yield return new WaitForSeconds(rotatePeriod);
        }
    }

}
