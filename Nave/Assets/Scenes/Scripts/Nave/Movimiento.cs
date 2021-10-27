using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Rigidbody rigibody;


    [SerializeField] float speed = 15;
    public bool modoAvion = true;
    public bool switcha = true;
    public bool moverse = true;
    // Start is called before the first frame update
    void Start()
    {
        rigibody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    public void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (switcha)
            {

                while (moverse)
                {
                    //rigibody.constraints = RigidbodyConstraints.None;
                    transform.Translate(Vector3.down * 0.01f * Time.deltaTime * speed);
                    if(transform.position.y <= -2.88f)  
                    {

                        //rigibody.constraints = RigidbodyConstraints.FreezePositionY;
                        moverse = false;
                        
                    }

                }

                modoAvion = false;
                switcha = false;
            }
            else
            {
                modoAvion = true;
                switcha = true;
                moverse = true;

            }

        }


        if (modoAvion == true)
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



            //Desplazamiento en Y
            float desplY = Input.GetAxis("Vertical") * speed;

            transform.Translate(Vector3.up * desplY * Time.deltaTime);

            if (transform.position.y <= -1.308465)
            {
                transform.position = new Vector3(transform.position.x, -1.308465f, transform.position.z);
            }

            if (transform.position.y >= 20)
            {
                transform.position = new Vector3(transform.position.x, 20f, transform.position.z);
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