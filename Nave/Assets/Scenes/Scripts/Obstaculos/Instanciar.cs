using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciar : MonoBehaviour
{
    [SerializeField] GameObject[] arrayObst;
    [SerializeField] GameObject[] arrayObstPiedras;

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
    }


    IEnumerator Arrayador()
    { 

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
                randomNum = Random.Range(3, 11);
            }

            else if (nivel == 3)
            {
                randomNum = Random.Range(4, 20);
            }

            else if (nivel == 4)
            {
                randomNum = Random.Range(4, 23);
            }

            else if (nivel == 5)
            {
                randomNum = Random.Range(4, arrayObst.Length);
            }

            else
            {
                randomNum = Random.Range(0, arrayObst.Length);
            }




            if (arrayObst[randomNum].tag == "Ventilador")
            {
                newPos = new Vector3(0, 10, transform.position.z);
                Instantiate(arrayObst[randomNum], newPos, Quaternion.identity);
            }

            else
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
                intervalo = intervalo / 2;
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
            
            if (arrayObst[Random.Range(0, 2)].tag == "Ventilador")
            {
                Vector3 initColPos = new Vector3(0, 10, n);
                Instantiate(arrayObst[Random.Range(0, 2)], initColPos, Quaternion.identity);
            }

            else
            {
                Vector3 initColPos = new Vector3(Random.Range(-13f, 13f), Random.Range(-2.88f, 20), n);
                Instantiate(arrayObst[Random.Range(0, 2)], initColPos, Quaternion.identity);
            }
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

}
