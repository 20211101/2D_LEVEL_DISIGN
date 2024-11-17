using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class RotateSpikeBox : MonoBehaviour
{
    public Light2D light2;
    public float rotatePeriod = 1;
    private void Start()
    {
        StartCoroutine(nameof(RotateCoroutine));
    }

    IEnumerator RotateCoroutine()
    {
        while(true)
        {
            light2.pointLightOuterAngle = 90;
            transform.rotation = Quaternion.Euler(0, 0, (transform.rotation.eulerAngles.z + 90) % 360);
            yield return new WaitForSeconds(rotatePeriod/4);
            light2.pointLightOuterAngle = 180;

            yield return new WaitForSeconds(rotatePeriod/4);
            light2.pointLightOuterAngle = 270;
            
            yield return new WaitForSeconds(rotatePeriod/4);
            light2.pointLightOuterAngle = 360;
            
            yield return new WaitForSeconds(rotatePeriod/4);
        }
    }

}
