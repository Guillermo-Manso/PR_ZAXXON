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

    [SerializeField] Slider vidaSlider;
    [SerializeField] Slider gasSlider;

    public float velGeneral;
    public int nivel = 1;
    public float intervalo;
    public float distanciaEntreObstaculos = 12;
    public Text puntuacion;
    public float puntos;
    public Text nivelador;
    // Start is called before the first frame update
    void Start()
    {
        destruirNave = GameObject.Find("NaveTanque").GetComponent<DestruirNave>();
        movimiento = GameObject.Find("Nave").GetComponent<Movimiento>();
        if (destruirNave.alive == true)
        {
            StartCoroutine("contador");
            StartCoroutine("contadorDePuntos");
            StartCoroutine("contadorDeVelocidad");
        }

        
    }

    IEnumerator contadorDePuntos()
    {
        while (destruirNave.alive)
        {
            if(movimiento.modoAvion == true)
            {
                puntos = Mathf.Round(puntos + 10 * velGeneral);
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                puntos = Mathf.Round(puntos + 6 * velGeneral);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    IEnumerator contador()
    {
        velGeneral = 30;
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
        vidaSlider.value = destruirNave.vidas;
        gasSlider.value = movimiento.gasolina;


        puntuacion.text = Mathf.Round(puntos).ToString();
        puntuacion.color = Color.white;

        nivelador.text ="Nivel " + nivel.ToString();
        nivelador.color = Color.white;

        if (destruirNave.alive == false)
        {
            if (puntos > GameManager.highScore)
            {
                GameManager.highScore = puntos;
            }

            else if (puntos < GameManager.highScore && puntos > GameManager.score2)
            {
                GameManager.score2 = puntos;
            }

            else if (puntos < GameManager.score2)
            {
                GameManager.score3 = puntos;
            }
        }

    }
}
