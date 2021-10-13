using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicio : MonoBehaviour
{

    public float velGeneral;
    int nivel = 1;
    public float intervalo;
    public float distanciaEntreObstaculos = 20;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("contador");
    }

    IEnumerator contador()
    {
        velGeneral = 20;
        int contar = 0;
        
        while (true)
        {
            contar++;
            //print(contar);
            intervalo = distanciaEntreObstaculos / velGeneral;

            yield return new WaitForSeconds(1f);

            if (contar == 10)
            {
                nivel++;
                print(nivel);
                velGeneral = velGeneral + 10;
                contar = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
