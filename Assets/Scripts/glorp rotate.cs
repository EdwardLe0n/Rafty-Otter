using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glorprotate : MonoBehaviour
{

    public float turnSpeed = 100f;

    // Update is called once per frame
    void Update()
    {

        this.transform.Rotate( (turnSpeed * Time.deltaTime * Random.value * 2f),
                                (turnSpeed * Time.deltaTime * Random.value),
                                (turnSpeed * Time.deltaTime * Random.value));

    }
}
