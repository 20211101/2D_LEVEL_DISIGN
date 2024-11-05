using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour
{
    PlayerCharacter playerCharacter;
    public Image coolTimeImg;
    void Start()
    {
        playerCharacter = PlayerCharacter.PlayerInstance;
    }

    void Update()
    {
        if (playerCharacter.IsCoolTime)
        {
            coolTimeImg.color = Color.black;
            coolTimeImg.fillAmount = playerCharacter.MeleeCurCoolTime / playerCharacter.MeleeCoolTime;
        }
        else
        {
            coolTimeImg.color = Color.white;
            coolTimeImg.fillAmount = 1;
        }

    }
}
