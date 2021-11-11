using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Rigidbody rigibody;


    [SerializeField] float speed = 10;
    public bool modoAvion = true;
    public bool switcha = true;
    public int gasolina;
    // Start is called before the first frame update
    void Start()
    {
        rigibody = GetComponent<Rigidbody>();
        gasolina = 400;
        StartCoroutine("BajarGasolina");
    }
    // Update is called once per frame
    public void Update()
    {

        if (Input.GetButtonDown("ModoAvion"))
        {
            if (switcha)
            {
                rigibody.constraints = RigidbodyConstraints.None;
                StopCoroutine("BajarGasolina");
                if (gasolina >= 0)
                {
                    modoAvion = false;
                    switcha = false;
                }
            }
            else
            {
                rigibody.constraints = RigidbodyConstraints.FreezePositionY;
                StartCoroutine("BajarGasolina");
                modoAvion = true;
                switcha = true;
            }

        }
        
        if (gasolina == 0)
        {
            rigibody.constraints = RigidbodyConstraints.None;

            modoAvion = false;
            if (transform.position.y < -2.88f)
            {
                rigibody.constraints = RigidbodyConstraints.FreezePositionY;
            }

        }
         
        //print(gasolina);
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

    IEnumerator BajarGasolina()
    {
        while (gasolina >= 0)
        {
            gasolina--;
            yield return new WaitForSeconds(0.075f);
        }
    }

}
