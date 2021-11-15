using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciar : MonoBehaviour
{
    [SerializeField] GameObject[] arrayObst;
    [SerializeField] GameObject[] arrayObstPiedras;

    [SerializeField] GameObject Gas;

    public GameObject Iniciar;
    private Inicio inicio;

    public GameObject NaveTanque;
    private DestruirNave destruirNave;
    // Start is called before the first frame update
    void Start()
    {

        inicio = GameObject.Find("Iniciar").GetComponent<Inicio>();

        destruirNave = GameObject.Find("NaveTanque").GetComponent<DestruirNave>();

        StartCoroutine("Arrayador");
        StartCoroutine("Piedras");
        CrearColumnasIniciales();
        CrearPiedrasIniciales();

        StartCoroutine("Gasolina");
    }


    IEnumerator Arrayador()
    {

        int contadorVentilador = 3;

        while (destruirNave.alive)
        {
            float intervalo = inicio.intervalo;
            float aleatorioX = Random.Range(-13, 13);
            float aleatorioY = Random.Range(-2.88f, 21.5f);
            Vector3 newPos;

            int nivel = inicio.nivel;
            int randomNum;

            if(nivel == 1)
            {
                randomNum = Random.Range(0,4);
            }

            else if(nivel == 2)
            {
                randomNum = Random.Range(3, 20);
            }

            else if (nivel == 3)
            {
                randomNum = Random.Range(3, 37);
            }

            else if (nivel == 4)
            {
                randomNum = Random.Range(3, 41);
            }

            else if (nivel == 5)
            {
                randomNum = Random.Range(0, arrayObst.Length);
            }

            else
            {
                randomNum = Random.Range(0, arrayObst.Length);
            }




            if (arrayObst[randomNum].CompareTag("Ventilador"))
            {
                if (contadorVentilador == 3)
                {
                    newPos = new Vector3(0, 10, transform.position.z);
                    Instantiate(arrayObst[randomNum], newPos, Quaternion.identity);
                    contadorVentilador = 0;
                }

                else
                {
                    contadorVentilador++;
                }
            }
            
            else if (arrayObst[randomNum].CompareTag("PinchoAbajo"))
            {
                newPos = new Vector3(aleatorioX, 5.92f, transform.position.z);
                Instantiate(arrayObst[randomNum], newPos, Quaternion.identity);
            }
            
            else if (arrayObst[randomNum].CompareTag("PinchoArriba"))
            {
                newPos = new Vector3(aleatorioX, 14.26f, transform.position.z);
                Instantiate(arrayObst[randomNum], newPos, Quaternion.identity);
            }
            
            if (arrayObst[randomNum].CompareTag("PinchoIzqda"))
            {
                newPos = new Vector3(-9.4f, aleatorioY, transform.position.z);
                Instantiate(arrayObst[randomNum], newPos, Quaternion.identity);
            }

            else if (arrayObst[randomNum].CompareTag("PinchoDcha"))
            {
                newPos = new Vector3(6.28f, aleatorioY, transform.position.z);
                Instantiate(arrayObst[randomNum], newPos, Quaternion.identity);
            }
            
            else if (arrayObst[randomNum].CompareTag("Obstaculo") || arrayObst[randomNum].CompareTag("PowerUp") || arrayObst[randomNum].CompareTag("Enemigo"))
            {
                newPos = new Vector3(aleatorioX, aleatorioY, transform.position.z);
                Instantiate(arrayObst[randomNum], newPos, Quaternion.identity);
            }
            
            yield return new WaitForSeconds(intervalo);
        }

    }

    IEnumerator Piedras()
    {

        while (destruirNave.alive)
        {
            float aleatorioX = Random.Range(-13, 13);
            float intervalo = inicio.intervalo;
            Vector3 piedras = new Vector3(aleatorioX, -2.88f, transform.position.z);
            int randomNum;
            int nivel = inicio.nivel;


            if (nivel == 1)
            {
                randomNum = Random.Range(0, 4);
            }

            else if (nivel == 2)
            {
                randomNum = Random.Range(3, 11);
            }

            else if (nivel == 3)
            {
                randomNum = Random.Range(12, 20);
            }

            else if (nivel == 4)
            {
                randomNum = Random.Range(4, 20);
            }

            else if (nivel == 5)
            {
                randomNum = Random.Range(4, 23);
            }

            else
            {
                randomNum = Random.Range(0, arrayObstPiedras.Length);
            }

            Instantiate(arrayObstPiedras[randomNum], piedras, Quaternion.identity);
            yield return new WaitForSeconds(intervalo);

        }
        
    }


    int distPrimerObst = 80;
    float distanciaEntreObstaculos = 20;
    void CrearColumnasIniciales()
    {

        float numColumnasIniciales = (transform.position.z - distPrimerObst) / distanciaEntreObstaculos;
        numColumnasIniciales = Mathf.Round(numColumnasIniciales); 


        for (float n = distPrimerObst; n < transform.position.z; n += distanciaEntreObstaculos)
        {
                Vector3 initColPos = new Vector3(Random.Range(-13f, 13f), Random.Range(-2.88f, 20), n);
                Instantiate(arrayObst[Random.Range(0, 2)], initColPos, Quaternion.identity);
        }
    }


    void CrearPiedrasIniciales()
    {

        float numColumnasIniciales = (transform.position.z - distPrimerObst) / distanciaEntreObstaculos;
        numColumnasIniciales = Mathf.Round(numColumnasIniciales);


        for (float n = distPrimerObst; n < transform.position.z; n += distanciaEntreObstaculos)
        {
            Vector3 initColPos = new Vector3(Random.Range(-13f, 13f), -2.88f, n);
            Instantiate(arrayObstPiedras[Random.Range(0, 2)], initColPos, Quaternion.identity);

        }
    }

    IEnumerator Gasolina()
    {
        while (destruirNave.alive == true && GameManager.modoGasolina == true)
        {
            float aleatorioX = Random.Range(-13, 13);
            Vector3 newPos = new Vector3(aleatorioX, -2.14f, transform.position.z);
            Instantiate(Gas, newPos, Quaternion.identity);
            yield return new WaitForSeconds(20f);
        }
    }

}
