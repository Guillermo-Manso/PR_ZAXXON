using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovLadrillo : MonoBehaviour
{
    public GameObject NaveTanque;
    private DestruirNave destruirNave;


    public GameObject Iniciar;
    private Inicio inicio;
    float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        destruirNave = GameObject.Find("NaveTanque").GetComponent<DestruirNave>();

        inicio = GameObject.Find("Iniciar").GetComponent<Inicio>();
        velocidad = inicio.velGeneral;

    }
     
    // Update is called once per frame
    void Update()
    {
        velocidad = inicio.velGeneral;
        transform.Translate(Vector3.back * Time.deltaTime * velocidad);

        float posZ = transform.position.z;
        if(posZ <= -25)
        {
            Destroy(gameObject);
        }

        if(destruirNave.alive == false)
        {
            StartCoroutine("DestruirTodo");
        }
        /*
        if(destruirNave.powerUp == true)
        {
            Destroy(gameObject);
        }
        */
    }

    IEnumerator DestruirTodo()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider Esfera)
    {
        if (Esfera.gameObject.name == "NaveTanque")
        {
            Destroy(gameObject);
        }
    }
}
