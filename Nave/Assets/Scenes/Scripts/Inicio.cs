using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicio : MonoBehaviour
{
    public GameObject NaveTanque;
    private DestruirNave destruirNave;


    public float velGeneral;
    public int nivel = 1;
    public float intervalo;
    public float distanciaEntreObstaculos = 10;
    // Start is called before the first frame update
    void Start()
    {
        destruirNave = GameObject.Find("NaveTanque").GetComponent<DestruirNave>();

        StartCoroutine("contador");
    }

    IEnumerator contador()
    {
        velGeneral = 20;
        int contar = 0;
        float cambioNivel = 30;
        
        while (destruirNave.alive)
        {
            contar++;
            //print(contar);
            intervalo = distanciaEntreObstaculos / velGeneral;

            yield return new WaitForSeconds(1f);

            if (contar >= cambioNivel)
            {
                nivel++;
                print("Nivel " + nivel);
                velGeneral = velGeneral + 20;
                contar = 0;
                cambioNivel = cambioNivel * 1.2f;
                
            }
        }
    }


    public void GameOver()
    {
        velGeneral = 0;
    }


    // Update is called once per frame
    void Update()
    {
        //print(velGeneral);
    }
}
