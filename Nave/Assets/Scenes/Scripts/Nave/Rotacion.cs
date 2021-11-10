using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{

    public GameObject Nave;
    private Movimiento movimiento;
    Vector3 rotacionZ = new Vector3(0f, 0f, -1f);
    Vector3 rotacionY = new Vector3(0f, -1f, 0f);
    Vector3 rotacionX = new Vector3(-1f, 0f, 0f);


    // Start is called before the first frame update
    void Start()
    {
        movimiento = GameObject.Find("Nave").GetComponent<Movimiento>();
    }
    void Update()
    {
        if (movimiento.modoAvion == true)
        {
            transform.rotation = Quaternion.AngleAxis(-30 * Input.GetAxis("Horizontal"), Vector3.forward);
        }

        else if(movimiento.modoAvion == false)
        {
            transform.rotation = Quaternion.AngleAxis(30 * Input.GetAxis("Horizontal"), Vector3.up);
        }
        
    }
}
