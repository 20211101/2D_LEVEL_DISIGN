using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class PitControll_1 : MonoBehaviour
{
    public Light2D bigLight;
    public BoxCollider2D colliderTrigger;
    public GameObject acid;
    public void StartHazard()
    {
        StartCoroutine("Hazard");
        colliderTrigger.isTrigger = true;
    }

    IEnumerator Hazard()
    {
        yield return StartCoroutine("LightRed");
        acid.SetActive(true);
    }

    IEnumerator LightRed()
    {
        float percent = 0;
        Color color = bigLight.color;
        while (percent < 1)
        {
            percent += Time.deltaTime / 3;
            bigLight.color = Color.Lerp(color, new Color(1,0,0,0.4f), percent);
            yield return null;
        }
    }
}
