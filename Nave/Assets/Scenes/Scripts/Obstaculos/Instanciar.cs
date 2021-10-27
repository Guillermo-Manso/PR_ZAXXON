using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciar : MonoBehaviour
{
    [SerializeField] GameObject[] arrayObst;

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
        CrearColumnasIniciales();
    }


    IEnumerator Arrayador()
    { 

        while (destruirNave.alive)
        {
            float intervalo = inicio.intervalo;
            float aleatorioX = Random.Range(-13, 13);
            float aleatorioY = Random.Range(-2.34f, 20);

            Vector3 newPos = new Vector3(aleatorioX, aleatorioY, transform.position.z);

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
                randomNum = Random.Range(0, arrayObst.Length);
            }



            Instantiate(arrayObst[randomNum], newPos, Quaternion.identity);

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
            Vector3 initColPos = new Vector3(Random.Range(-13f, 13f), Random.Range(-2.34f, 20), n);
            Instantiate(arrayObst[Random.Range(0,2)], initColPos, Quaternion.identity);

        }
    }

}