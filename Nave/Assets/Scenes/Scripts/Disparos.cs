using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine("Disparar");
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopCoroutine("Disparar");
        }

    }
    int numeroDisparos = 1;
    IEnumerator Disparar()
    {
        

        while (true)
        {
            print("Disparo " + numeroDisparos);
            numeroDisparos++;
            yield return new WaitForSeconds(0.2f);
        }
    }

}
