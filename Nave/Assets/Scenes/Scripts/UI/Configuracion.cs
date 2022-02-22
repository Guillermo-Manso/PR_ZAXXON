using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Configuracion : MonoBehaviour
{
    public AudioMixer audioMixer;

    public GameObject boton;

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
        boton.SendMessage("SonidoBoton");
    }

    public void DesctivarGasolina()
    {
        GameManager.modoGasolina = false;
        boton.SendMessage("SonidoBoton");
    }
    public void SetSound(string tipoVolumen, float nivelVol)
    {
        audioMixer.SetFloat(tipoVolumen, nivelVol);
    }
    public void Update()
    {
        GameManager.dificultad = diffSlider.value;
        volSlider.onValueChanged.AddListener(delegate { SetSound("Master", volSlider.value); });


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
