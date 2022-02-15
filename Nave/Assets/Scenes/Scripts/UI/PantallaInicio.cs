using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaInicio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Jugar()
    {
        SceneManager.LoadScene(1);
        GameManager.musicaInicial = false;
    }

    public void Highscores()
    {
        SceneManager.LoadScene(2);
    }

    public void Configuracion()
    {
        SceneManager.LoadScene(3);
    }

    public void Atras()
    {
        SceneManager.LoadScene(0);
    }

    public void SaliJuego()
    {
        Application.Quit();
    }

}
