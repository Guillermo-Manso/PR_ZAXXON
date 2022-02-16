using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaInicio : MonoBehaviour
{
    AudioSource boton;

    public GameObject Musica;
    // Start is called before the first frame update
    void Start()
    {
        boton = GetComponent<AudioSource>();
    }

    public void Jugar()
    {
        Musica.SendMessage("SonidoBoton");
        SceneManager.LoadScene(1);
        GameManager.musicaInicial = false;
    }

    public void Highscores()
    {
        Musica.SendMessage("SonidoBoton");
        SceneManager.LoadScene(2);
    }

    public void Configuracion()
    {
        Musica.SendMessage("SonidoBoton");
        SceneManager.LoadScene(3);
    }

    public void Atras()
    {
        Musica.SendMessage("SonidoBoton");
        SceneManager.LoadScene(0);
    }

    public void SaliJuego()
    {
        Musica.SendMessage("SonidoBoton");
        Application.Quit();
    }

}
