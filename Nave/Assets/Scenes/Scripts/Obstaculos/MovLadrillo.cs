using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovLadrillo : MonoBehaviour
{
    public GameObject NaveTanque;
    private DestruirNave destruirNave;


    public GameObject Iniciar;
    private Inicio inicio;

    GameObject GameOver;
    Canvas MenuGameOver;
    [SerializeField] Button Button;

    float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        

        GameOver = GameObject.Find("MenuGameOver");
        MenuGameOver = GameOver.GetComponent<Canvas>();
        MenuGameOver.enabled = false;

        

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
    }

    IEnumerator DestruirTodo()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        MenuGameOver.enabled = true;
        Button.Select();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Nave"))
        {
            Destroy(gameObject);    
        }
    }
}
