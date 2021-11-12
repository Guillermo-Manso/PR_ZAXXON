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
        if (movimiento.transform.position.y >= -1.308465f)
        {
            transform.rotation = Quaternion.Euler(-30 * Input.GetAxis("Vertical"), 0, -30 * Input.GetAxis("Horizontal"));
        }

        else if(movimiento.transform.position.y == -2.88f)
        {
            transform.rotation = Quaternion.Euler(0, 30 * Input.GetAxis("Horizontal"), 0);
        }
        
    }
}
