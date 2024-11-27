using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour
{
    PlayerCharacter playerCharacter;
    [SerializeField]
    LineRenderer lineRenderer;
    public Image coolTimeImg;
    void Start()
    {
        playerCharacter = PlayerCharacter.PlayerInstance;
    }

    void Update()
    {
        if (playerCharacter.IsCoolTime)
        {
            lineRenderer.endColor = new Color(1,0,0,0.1f);
            if(coolTimeImg != null)
            {
                coolTimeImg.color = Color.black;
                coolTimeImg.fillAmount = playerCharacter.MeleeCurCoolTime / playerCharacter.MeleeCoolTime;
            }
        }
        else
        {
            lineRenderer.endColor = Color.white;
            if(coolTimeImg != null)
            {
                coolTimeImg.color = Color.white;
                coolTimeImg.fillAmount = 1;
            }
        }

    }
}
