using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovLadrillo : MonoBehaviour
{

    public GameObject Iniciar;
    private Inicio inicio;
    float velocidad;
    // Start is called before the first frame update
    void Start()
    {

        inicio = Iniciar.GetComponent<Inicio>();
        velocidad = inicio.velGeneral;

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.back * Time.deltaTime * velocidad);

        float posZ = transform.position.z;
        if(posZ <= -25)
        {
            Destroy(gameObject);
        }

    }
}
