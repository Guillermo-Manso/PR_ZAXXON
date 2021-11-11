using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{

    public GameObject Nave;
    private Movimiento movimiento;

    // Start is called before the first frame update
    void Start()
    {
        movimiento = GameObject.Find("Nave").GetComponent<Movimiento>();
    }
    void Update()
    {
        if (movimiento.modoAvion == true)
        {
            transform.rotation = Quaternion.Euler(-30 * Input.GetAxis("Vertical"), 0, -30 * Input.GetAxis("Horizontal"));
        }

        else if(movimiento.modoAvion == false)
        {
            transform.rotation = Quaternion.Euler(0, 30 * Input.GetAxis("Horizontal"), 0);
        }
        
    }
}
