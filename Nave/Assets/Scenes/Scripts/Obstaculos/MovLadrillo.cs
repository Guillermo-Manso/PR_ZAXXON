using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovLadrillo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float velocidad = 20;
        transform.Translate(Vector3.back * Time.deltaTime * velocidad);

        float posZ = transform.position.z;
        if(posZ <= -25)
        {

            Destroy(gameObject);

        }

    }
}
