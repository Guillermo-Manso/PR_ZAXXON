using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaJuego : MonoBehaviour
{
    InputManager inputManager;


    AudioSource Musica;
    public AudioClip Musica1;
    public AudioClip Musica2;
    public AudioClip Musica3;

    int aleatorizador;
    int ultimaCancion;

    float finClip;


    private void Awake()
    {
        inputManager = new InputManager();

        inputManager.Hola.R1.started += a => NextSong();

        inputManager.Hola.L1.started += a => PrevSong();
    }

    void NextSong()
    {
        StopCoroutine("ReproducirMusica");
        aleatorizador++;
        if (aleatorizador == 4)
        {
            aleatorizador = 1;
        }
        StartCoroutine("ReproducirMusica");
    }

    void PrevSong()
    {
        StopCoroutine("ReproducirMusica");
        aleatorizador--;
        if (aleatorizador == 0)
        {
            aleatorizador = 3;
        }
        StartCoroutine("ReproducirMusica");
    }


    // Start is called before the first frame update
    void Start()
    {
        Musica = GetComponent<AudioSource>();
        StartCoroutine("ReproducirMusica");
        aleatorizador = Random.Range(1, 4);
    }

    IEnumerator ReproducirMusica()
    {
        while (true)
        {
            while(aleatorizador == ultimaCancion)
            {
                aleatorizador = Random.Range(1, 4);
            }
            if (aleatorizador == 1)
            {
                Musica.clip = Musica1;
                Musica.Play();
                finClip = Musica.clip.length;
            }
            else if (aleatorizador == 2)
            {
                Musica.clip = Musica2;
                Musica.Play();
                finClip = Musica.clip.length;
            }
            else if (aleatorizador == 3)
            {
                Musica.clip = Musica3;
                Musica.Play();
                finClip = Musica.clip.length;
            }
            ultimaCancion = aleatorizador;
            print(aleatorizador);
            yield return new WaitForSeconds(finClip);
            aleatorizador = Random.Range(1, 4);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnEnable()
    {
        inputManager.Enable();
    }
    private void OnDisable()
    {
        inputManager.Disable();
    }

}
