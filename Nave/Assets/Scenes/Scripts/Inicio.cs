using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inicio : MonoBehaviour
{
    public GameObject NaveTanque;
    private DestruirNave destruirNave;


    public float velGeneral;
    public int nivel = 1;
    public float intervalo;
    public float distanciaEntreObstaculos = 10;
    public Text puntuacion;
    public static int puntos;
    // Start is called before the first frame update
    void Start()
    {
        puntuacion.text = "Puntuación";
        puntuacion.color = Color.white;

        destruirNave = GameObject.Find("NaveTanque").GetComponent<DestruirNave>();

        StartCoroutine("contador");
        StartCoroutine("contadorDePuntos");
    }

    IEnumerator contadorDePuntos()
    {
        while (true)
        {
            puntos++;
             yield return new WaitForSeconds(1f);
        }
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
                velGeneral = velGeneral + 10;
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
        
    }
}
