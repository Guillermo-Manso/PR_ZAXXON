using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{

    public GameObject Nave;
    private Movimiento movimiento;
    Vector3 rotacionZ = new Vector3(0f, 0f, -1f);
    Vector3 rotacionY = new Vector3(0f, 1f, 0f);


    // Start is called before the first frame update
    void Start()
    {

        movimiento = Nave.GetComponent<Movimiento>();

    }
    void Update()
    {
        float velocidadRot = 1500f;
        if (movimiento.modoAvion == true)
        {
            float rotar = Input.GetAxis("Horizontal");
            transform.Rotate(rotacionZ * Time.deltaTime * rotar * velocidadRot);
        }

        else if(movimiento.modoAvion == false)
        {
            float rotar = Input.GetAxis("Horizontal");
            transform.Rotate(rotacionY * Time.deltaTime * rotar * velocidadRot);
        }
        
    }
}
