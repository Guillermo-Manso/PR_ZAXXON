using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Configuracion : MonoBehaviour
{
    [SerializeField] Slider volSlider;
    [SerializeField] Slider diffSlider;
    public Text tipoDeDificultad;
    public string letrasDif;

    public string facil = ("Facil");
    public string normal = ("Normal");
    public string dificil = ("Dificil");
    public string muyDificil = ("Muy Dificil");

    public Text actGas;
    public string tipoGas;

    public string activado = ("Activado");
    public string desActivado = ("Desactivado");


    // Start is called before the first frame update
    void Start()
    {
        volSlider.value = GameManager.volMusica;
        diffSlider.value = GameManager.dificultad;
    }

    public void CambiarVolumen()
    {
        GameManager.volMusica = volSlider.value;
    }

    public void ActivarGasolina()
    {
        GameManager.modoGasolina = true;
    }

    public void DesctivarGasolina()
    {
        GameManager.modoGasolina = false;
    }

    public void Update()
    {
        GameManager.dificultad = diffSlider.value;

        if (GameManager.dificultad == 4)
        {
            letrasDif = muyDificil;
        }

        if (GameManager.dificultad == 3)
        {
            letrasDif = dificil;
        }

        if (GameManager.dificultad == 2)
        {
            letrasDif = normal;
        }

        if (GameManager.dificultad == 1)
        {
            letrasDif = facil;
        }

        tipoDeDificultad.text = letrasDif;

        if (GameManager.modoGasolina == true)
        {
            tipoGas = activado;
        }

        if (GameManager.modoGasolina == false)
        {
            tipoGas = desActivado;
        }

        actGas.text = tipoGas;
    }
}
