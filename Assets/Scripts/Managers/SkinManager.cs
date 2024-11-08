using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    [Tooltip("Tick this to enable monitoring of a skin change within current scene")]
    public bool monitor;

    [Tooltip("The script for spinning preview within character select")]
    public AxisYSpinRect preview;

    private Sprite skin;
    private int id;

    private void Start()
    {
        id = PlayerPrefs.GetInt("CurrentSkin", 0);
        UpdateSkin(id);

        if (!monitor)
        {
            return;
        }

        StartCoroutine(nameof(CheckSkin));
    }

    // every thenth of a second, check for a skin update
    private IEnumerator CheckSkin()
    {
        while (true)
        {
            if (PlayerPrefs.GetInt("CurrentSkin") != id)
            {
                id = PlayerPrefs.GetInt("CurrentSkin");
                UpdateSkin(id);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void UpdateSkin(int id)
    {
        Object[] sprites = Resources.LoadAll("Sprites", typeof(Sprite));

        skin = (Sprite)sprites[id];

        GameObject[] skinnables = GameObject.FindGameObjectsWithTag("Otter");

        foreach (GameObject item in skinnables)
        {
            // if item layer is UI
            if(item.layer == 5)
            {
                item.GetComponent<Image>().sprite = skin;
            }
            else
            {
                item.GetComponent<SpriteRenderer>().sprite = skin;
            }
        }

        if(preview == null)
        {
            return;
        }

        preview.Burst();
    }
}
