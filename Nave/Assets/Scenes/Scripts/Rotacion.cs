using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    public float hola = 1;

    Vector3 rotacion = new Vector3(0f, 0f, -1f);


    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {

        float rotar = Input.GetAxis("Horizontal");
        float velocidad = 1500f;
        transform.Rotate(rotacion * Time.deltaTime * rotar * velocidad);
    }
}
