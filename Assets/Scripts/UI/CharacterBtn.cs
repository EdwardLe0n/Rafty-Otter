using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Sprite))]

public class CharacterBtn : MonoBehaviour
{
    public Sprite sprite;
    private Image img;
    public int skinID;

    private void Awake()
    {
        img = GetComponent<Image>();
        SetData(sprite, skinID);
    }

    public void SetData(Sprite _sprite, int id)
    {
        sprite = _sprite;
        img.sprite = sprite;
        skinID = id;
    }

    public void UseSkin()
    {
        if(PlayerPrefs.GetInt("CurrentSkin", -1) == skinID)
        {
            return;
        }
        
        Debug.Log("Switching skin to: " + skinID);
        
        PlayerPrefs.SetInt("CurrentSkin", skinID);
    }
}
