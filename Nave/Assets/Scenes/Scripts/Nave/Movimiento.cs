using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Rigidbody rigibody;


    [SerializeField] float speed = 15;
    public bool modoAvion = true;
    public bool switcha = true;
    // Start is called before the first frame update
    void Start()
    {
        rigibody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    public void Update()
    {

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (switcha)
            {
                rigibody.constraints = RigidbodyConstraints.None;
                
                modoAvion = false;
                switcha = false;
            }
            else
            {
                //rigibody.AddForce(transform.up * 10);
                modoAvion = true;
                switcha = true;
            }

        }


        if (modoAvion == true)
        {
            //Ascenso desde el suelo
            if (transform.position.y < -1.308465)
            {
                transform.Translate(Vector3.up * 10 * Time.deltaTime);
            }

            //Desplazamiento en X
            float desplX = Input.GetAxis("Horizontal") * speed;

            transform.Translate(Vector3.left * -desplX * Time.deltaTime);

            if (transform.position.x >= 13)
            {
                transform.position = new Vector3(13f, transform.position.y, transform.position.z);
            }
            else if (transform.position.x <= -13)
            {
                transform.position = new Vector3(-13f, transform.position.y, transform.position.z);
            }


            //Desplazamiento en Y
            if (transform.position.y >= -1.308465)
            {
                float desplY = Input.GetAxis("Vertical") * speed;

                transform.Translate(Vector3.up * desplY * Time.deltaTime);

                if (transform.position.y <= -1.308465)
                {
                    transform.position = new Vector3(transform.position.x, -1.308465f, transform.position.z);
                }

                if (transform.position.y >= 21.26085f)
                {
                    transform.position = new Vector3(transform.position.x, 21.26085f, transform.position.z);
                }
            }
            
        }


        else
        {

            
            //Desplazamiento en X
            float desplX = Input.GetAxis("Horizontal") * speed;

            transform.Translate(Vector3.left * -desplX * Time.deltaTime);

            if (transform.position.x >= 13)
            {
                transform.position = new Vector3(13f, transform.position.y, transform.position.z);
            }
            else if (transform.position.x <= -13)
            {
                transform.position = new Vector3(-13f, transform.position.y, transform.position.z);
            }

        }


    }

}
