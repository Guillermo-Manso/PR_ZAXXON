using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inicio : MonoBehaviour
{
    public GameObject NaveTanque;
    private DestruirNave destruirNave;

    public GameObject Nave;
    private Movimiento movimiento;


    public float velGeneral;
    public int nivel = 1;
    public float intervalo;
    public float distanciaEntreObstaculos = 15;
    public Text puntuacion;
    public static float puntos;
    public Text nivelador;
    public Text vidass;
    // Start is called before the first frame update
    void Start()
    {
        destruirNave = GameObject.Find("NaveTanque").GetComponent<DestruirNave>();
        movimiento = GameObject.Find("Nave").GetComponent<Movimiento>();

        StartCoroutine("contador");
        StartCoroutine("contadorDePuntos");
        StartCoroutine("contadorDeVelocidad");
    }

    IEnumerator contadorDePuntos()
    {
        while (destruirNave.alive)
        {
            if(movimiento.modoAvion == true)
            {
                puntos = puntos + 10 * velGeneral;
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                puntos = puntos + 12 * velGeneral;
                yield return new WaitForSeconds(0.1f);
            }
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
                //print("Nivel " + nivel);
                contar = 0;
                cambioNivel = cambioNivel * 1.2f;
                
            }
        }
    }


    public void GameOver()
    {
        velGeneral = 0;
    }

    IEnumerator contadorDeVelocidad()
    {
        while (destruirNave.alive)
        {
            if (nivel < 4)
            {
                yield return new WaitForSeconds(1f);
                velGeneral = velGeneral + 0.4f;
            }

            else
            {
                yield return new WaitForSeconds(1f);
                velGeneral = velGeneral + 0.1f;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        puntuacion.text = Mathf.Round(puntos).ToString();
        puntuacion.color = Color.white;

        nivelador.text = nivel.ToString();
        nivelador.color = Color.white;

        vidass.text = destruirNave.vidas.ToString();
        vidass.color = Color.white;
        //print(velGeneral);
    }
}
