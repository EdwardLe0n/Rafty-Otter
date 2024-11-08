using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOtters : MonoBehaviour
{
    [Header("Unity Setup")]
    [Tooltip("The button prefab. DO NOT CHANGE")]
    public GameObject btnPrefab;
    [Tooltip("The Grid Layout Parent. DO NOT CHANGE")]
    public Transform gridLayout;

    private void Start()
    {
        Object[] sprites = Resources.LoadAll("Sprites", typeof(Sprite));

        for (int i = 0; i < sprites.Length; i++)
        {
            GameObject instance = Instantiate(btnPrefab, gridLayout);
            instance.GetComponent<CharacterBtn>().SetData((Sprite)sprites[i], i);
        }
    }
}
