using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Rigidbody rigibody;

    InputManager inputManager;

    public GameObject NaveTanque;
    private DestruirNave destruirNave;

    public GameObject Iniciar;
    private Inicio inicio;


    Vector2 joyIzqdo;


    [SerializeField] float speed = 15;
    public bool modoAvion = true;
    public bool switcha = true;
    public int gasolina;
    public bool cayendo = false;


    public AudioSource audioSource;
    [SerializeField] AudioClip Powerup;
    public AudioClip Golpe;

    private void Awake()
    {
        inputManager = new InputManager();

        inputManager.Hola.MoverNave.performed += a => joyIzqdo = a.ReadValue<Vector2>();
        inputManager.Hola.MoverNave.canceled += a => joyIzqdo = Vector2.zero;


        inputManager.Hola.Pausa.started += a => inicio.SendMessage("Pausate");

        inputManager.Hola.BotonConfirmacion.started += a => Boton();
    }



    // Start is called before the first frame update
    void Start()
    {
        inicio = GameObject.Find("Iniciar").GetComponent<Inicio>();
        destruirNave = GameObject.Find("NaveTanque").GetComponent<DestruirNave>();
        rigibody = GetComponent<Rigidbody>();
        gasolina = 400;
        StartCoroutine("BajarGasolina");
        audioSource = GetComponent<AudioSource>();

    }
    // Update is called once per frame
    public void Update()
    {
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
            if (transform.position.y < -1)
            {
                transform.Translate(Vector3.up * 10 * Time.deltaTime);
            }

            //Desplazamiento en X
            float desplX = joyIzqdo.x * speed;

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
            if (transform.position.y >= -1)
            {
                float desplY = joyIzqdo.y * speed;

                transform.Translate(Vector3.up * desplY * Time.deltaTime);

                if (transform.position.y <= -1)
                {
                    transform.position = new Vector3(transform.position.x, -1, transform.position.z);
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
            float desplX = joyIzqdo.x * speed;

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
        while (gasolina >= 0 && destruirNave.alive == true && GameManager.modoGasolina == true)
        {
            gasolina--;
            yield return new WaitForSeconds(0.075f);
        }
    }

    void Boton()
    {
        if(inicio.movilidad == true && GameManager.modoGasolina == true && gasolina > 0)
        {
            if (switcha)
            {
                rigibody.constraints = RigidbodyConstraints.None;
                StopCoroutine("BajarGasolina");
                modoAvion = false;
                switcha = false;
                cayendo = true;
            }
            else
            {
                rigibody.constraints = RigidbodyConstraints.FreezePositionY;
                StartCoroutine("BajarGasolina");
                modoAvion = true;
                switcha = true;
                cayendo = false;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp") || other.gameObject.CompareTag("Gasolina"))
        {
            audioSource.PlayOneShot(Powerup, 1);
        }
    }





    private void OnEnable()
    {
        inputManager.Enable();
    }
    private void OnDisable()
    {
        inputManager.Disable();
    }
}
