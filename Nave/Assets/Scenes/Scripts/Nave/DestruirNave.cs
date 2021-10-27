using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirNave : MonoBehaviour
{

    public GameObject Iniciar;
    private Inicio inicio;
    public bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        inicio = GameObject.Find("Iniciar").GetComponent<Inicio>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Obstaculo"))
        {
            Destroy(gameObject);
            inicio.velGeneral = 0;
            alive = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
