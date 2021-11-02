using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject NaveTanque;
    private DestruirNave destruirNave;


    [SerializeField] Transform playerPosition;
    //Variables necesarias para la opción de suavizado
    float smoothVelocity = 0.1f;
    Vector3 camaraVelocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        destruirNave = GameObject.Find("NaveTanque").GetComponent<DestruirNave>();
    }

    // Update is called once per frame
    void Update()
    {
        if(destruirNave.alive == true)
        {
            Vector3 targetPosition = new Vector3(playerPosition.position.x, playerPosition.position.y + 1.5f, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref camaraVelocity, smoothVelocity);
        }
        
    }
}
