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

    public int vidas;
    public int cargas = 0;

    int daño = 34;
    int sobrante = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigibody = GameObject.Find("Nave").GetComponent<Rigidbody>();
        movimiento = GameObject.Find("Nave").GetComponent<Movimiento>();

        inicio = GameObject.Find("Iniciar").GetComponent<Inicio>();
        vidas = 100;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Enemigo") || other.gameObject.CompareTag("Obstaculo") ||other.gameObject.CompareTag("Obstaculo") || other.gameObject.CompareTag("Ventilador") || other.gameObject.CompareTag("PinchoAbajo") || other.gameObject.CompareTag("PinchoArriba") || other.gameObject.CompareTag("PinchoIzqda") || other.gameObject.CompareTag("PinchoDcha"))
        {
            if (other.gameObject.CompareTag("Enemigo") || other.gameObject.CompareTag("Ventilador"))
            {
                daño = 50;
            }

            else if (other.gameObject.CompareTag("Obstaculo"))
            {
                daño = 20;
            }
            else
            {
                daño = 34;
            }

            cargas = cargas - daño;

            if (cargas <= 0)
            {
                sobrante = -cargas;
            }

            if (vidas > 0)
            {
                if (cargas <= 0)
                {
                    vidas = vidas - sobrante;
                    cargas = 0;
                }
            }

            else if (vidas <= 0)
            {
                inicio.velGeneral = 0;
                alive = false;
            }
            Destroy(other.gameObject);

        }

        if (other.gameObject.CompareTag("PowerUp") && cargas <= 100)
        {
            StartCoroutine("SubirEscudo");
            //cargas = cargas + 10;
            if(cargas >= 100)
            {
                cargas = 100;
            }
        }

        if (other.gameObject.CompareTag("Gasolina"))
        {
            movimiento.gasolina = 400;
            movimiento.switcha = false;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Suelo"))
        {
            rigibody.constraints = RigidbodyConstraints.FreezePositionY;
            movimiento.transform.position = new Vector3(transform.position.x, -2.88f, 0);
        }

    }

    IEnumerator SubirEscudo()
    {
        int f = 0;
        while (f <= 10)
        {
            f++;
            cargas++;
            yield return new WaitForSeconds(0.0125f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            vidas = vidas + 10000;
            inicio.nivel++;
        }


        if (vidas <= 0)
        {
            Destroy(gameObject);
            inicio.velGeneral = 0;
            alive = false;
        }
    }
}
