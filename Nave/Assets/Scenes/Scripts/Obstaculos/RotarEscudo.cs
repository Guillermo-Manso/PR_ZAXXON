using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarEscudo : MonoBehaviour
{
    float vel;
    // Start is called before the first frame update
    void Start()
    {
        vel = 150f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 1 * Time.deltaTime * vel, 0);
    }
}
