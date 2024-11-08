using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisYSpinRect : MonoBehaviour
{
    [Tooltip("Rotation speed in angle per second")]
    public float speed;
    [Tooltip("Extra burst initial value")]
    public float burst;
    [Tooltip("Extra burst decay per second")]
    public float decay;

    private float modifier;
    private RectTransform rform;

    private void Awake()
    {
        modifier = 1;
        rform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        float useSpeed = speed * modifier;
        modifier -= decay * Time.deltaTime;
        modifier = Mathf.Clamp(modifier, 1, 100);
        rform.Rotate(Vector3.up, useSpeed * Time.deltaTime);
    }

    public void Burst()
    {
        modifier = burst;
    }
}
