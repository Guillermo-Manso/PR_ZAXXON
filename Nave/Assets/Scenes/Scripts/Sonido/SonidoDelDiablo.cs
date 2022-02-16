using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoDelDiablo : MonoBehaviour
{
    public AudioSource boton;
    public void SonidoBoton()
    {
        boton.Play();
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
