using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaInicial : MonoBehaviour
{
    public AudioSource musicaInicial;
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.musicaInicial == false)
        {
            musicaInicial.Play();
            DontDestroyOnLoad(gameObject);
            GameManager.musicaInicial = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.musicaInicial == false)
        {
            Destroy(gameObject);
        }
    }
}
