using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject NaveTanque;
    private DestruirNave destruirNave;
    private Movimiento movimiento;


    [SerializeField] Transform playerPosition;
    //Variables necesarias para la opción de suavizado
    float smoothVelocity = 0.1f;
    Vector3 camaraVelocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        destruirNave = GameObject.Find("NaveTanque").GetComponent<DestruirNave>();
        movimiento = GameObject.Find("Nave").GetComponent<Movimiento>();

    }

    // Update is called once per frame
    void Update()
    {
        if(destruirNave.alive == true && movimiento.cayendo == false)
        {
            Vector3 targetPosition = new Vector3(playerPosition.position.x, playerPosition.position.y + 1.5f, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref camaraVelocity, smoothVelocity);
        }
        
    }

    private void FixedUpdate()
    {
        if (destruirNave.alive == true && movimiento.cayendo == true)
        {
            Vector3 targetPosition = new Vector3(playerPosition.position.x, playerPosition.position.y + 1.5f, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref camaraVelocity, smoothVelocity);
        }
    }
}
