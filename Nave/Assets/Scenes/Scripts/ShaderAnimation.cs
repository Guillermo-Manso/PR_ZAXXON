using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderAnimation : MonoBehaviour
{
    public GameObject Iniciar;
    private Inicio inicio;

    [SerializeField] Material material;
    float velTex;
    float velInicial;
    // Start is called before the first frame update
    void Start()
    {
        inicio = GameObject.Find("Iniciar").GetComponent<Inicio>();
        velInicial = inicio.velGeneral * 0.005f;
        material.SetFloat("Vector1_c22637d292894e99a835c1f7b4072b13", velInicial);
    }

    // Update is called once per frame
    void Update()
    {
        velTex = inicio.velGeneral * 0.005f;
        //velTex = 0.15f;
        //velTex += 0.0005f;
        material.SetFloat("Vector1_c22637d292894e99a835c1f7b4072b13", velTex);
    }
}
