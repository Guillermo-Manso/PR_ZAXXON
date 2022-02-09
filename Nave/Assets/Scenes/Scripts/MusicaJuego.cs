using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaJuego : MonoBehaviour
{
    AudioSource Musica;
    public AudioClip Musica1;
    public AudioClip Musica2;
    public AudioClip Musica3;

    int aleatorizador;
    float finClip;
    // Start is called before the first frame update
    void Start()
    {
        Musica = GetComponent<AudioSource>();
        aleatorizador = Random.Range(1, 4);
        StartCoroutine("ReproducirMusica");
    }

    IEnumerator ReproducirMusica()
    {
        switch (aleatorizador)
        {
            case 1:
                Musica.clip = Musica1;
                Musica.Play();
                finClip = Musica.clip.length;
                break;
            case 2:
                Musica.clip = Musica2;
                Musica.Play();
                finClip = Musica.clip.length;
                break;
            case 3:
                Musica.clip = Musica3;
                Musica.Play();
                finClip = Musica.clip.length;
                break;
            default:
                break;
        }
        print(aleatorizador);
        yield return new WaitForSeconds(finClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
