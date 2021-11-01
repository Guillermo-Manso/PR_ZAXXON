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
    // Start is called before the first frame update
    void Start()
    {
        rigibody = GameObject.Find("Nave").GetComponent<Rigidbody>();
        movimiento = GameObject.Find("Nave").GetComponent<Movimiento>();

        inicio = GameObject.Find("Iniciar").GetComponent<Inicio>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Obstaculo"))
        {
            Destroy(gameObject);
            inicio.velGeneral = 0;
            alive = false;
        }

        if (other.gameObject.CompareTag("PowerUp"))
        {
            powerUp = true;
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
