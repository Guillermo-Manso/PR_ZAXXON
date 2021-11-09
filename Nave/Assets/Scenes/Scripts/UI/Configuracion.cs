using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Configuracion : MonoBehaviour
{
    [SerializeField] Slider volSlider;




    // Start is called before the first frame update
    void Start()
    {
        volSlider.value = GameManager.volMusica;
    }

    public void CambiarVolumen()
    {
        GameManager.volMusica = volSlider.value;
    }

}
