using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirNave : MonoBehaviour
{
    public GameObject Nave;
    private Rigidbody rigibody;
    private Movimiento movimiento;

    public GameObject Iniciar;
    private Inicio inicio;
    public bool alive = true;
    public bool powerUp = false;

    public int vidas;
    int v = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigibody = GameObject.Find("Nave").GetComponent<Rigidbody>();
        movimiento = GameObject.Find("Nave").GetComponent<Movimiento>();

        inicio = GameObject.Find("Iniciar").GetComponent<Inicio>();
        vidas = 3;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Obstaculo") || other.gameObject.CompareTag("Ventilador"))
        {
            if (vidas > 0)
            {
                vidas--;
            }

            else if (vidas <= 0)
            {
                Destroy(gameObject);
                inicio.velGeneral = 0;
                alive = false;
            }
            
        }

        if (other.gameObject.CompareTag("PowerUp"))
        {
            powerUp = true;
            v++;
            print(v);
            if(v == 5)
            {
                vidas++;
                v = 0;
            }
        }

        if (other.gameObject.CompareTag("Suelo"))
        {
            rigibody.constraints = RigidbodyConstraints.FreezePositionY;
            movimiento.transform.position = new Vector3(transform.position.x, -2.88f, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
