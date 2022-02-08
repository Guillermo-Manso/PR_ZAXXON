using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inicio : MonoBehaviour
{
    public GameObject NaveTanque;
    private DestruirNave destruirNave;

    public GameObject Nave;
    private Movimiento movimiento;

    [SerializeField] Slider vidaSlider;
    [SerializeField] Slider gasSlider;
    [SerializeField] Slider ShieldSlider;

    GameObject GameOver;
    Canvas MenuGameOver;
    [SerializeField] Button BotonPorDefecto;


    GameObject Pausa;
    Canvas MenuPausa;
    [SerializeField] Button BotonDePausa;
    [SerializeField] Button BotonDesactivado;
    [SerializeField] Button BotonDePausa2;

    [SerializeField] Image GasImage;

    
    [SerializeField] GameObject Config;
    Canvas MenuConfig;
    [SerializeField] Button BotonDeConfig;
    
    public float velGeneral;
    public int nivel = 1;
    public float intervalo;
    public float distanciaEntreObstaculos = 12;
    public Text puntuacion;
    public float puntos;
    public Text nivelador;
    public Text puntuacion2;

    public bool modoPausa = false;
    public bool movilidad = true;

    public bool configurar = false;

    [SerializeField] Slider diffSlider;
    public Text tipoDeDificultad;
    public string letrasDif;

    public string facil = ("Facil");
    public string normal = ("Normal");
    public string dificil = ("Dificil");
    public string muyDificil = ("Muy Dificil");

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.modoGasolina == false)
        {
            gasSlider.transform.position = new Vector3(0, -100, 0);
            GasImage.transform.position = new Vector3(0, -100, 0);
        }

        if (Time.timeScale == 0)
        {
            Time.timeScale = 1 - Time.timeScale;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }

        destruirNave = GameObject.Find("NaveTanque").GetComponent<DestruirNave>();
        movimiento = GameObject.Find("Nave").GetComponent<Movimiento>();
        
        //Config = GameObject.Find("MenuConfig");
        MenuConfig = Config.GetComponent<Canvas>();
        MenuConfig.enabled = false;
        
        GameOver = GameObject.Find("MenuGameOver");
        MenuGameOver = GameOver.GetComponent<Canvas>();
        MenuGameOver.enabled = false;

        GameOver = GameObject.Find("MenuPausa");
        MenuPausa = GameOver.GetComponent<Canvas>();
        MenuPausa.enabled = false;

        diffSlider.value = GameManager.dificultad;


        if (destruirNave.alive == true)
        {
            StartCoroutine("contador");
            StartCoroutine("contadorDePuntos");
            StartCoroutine("contadorDeVelocidad");
        }
    }

    IEnumerator contadorDePuntos()
    {
        while (destruirNave.alive)
        {
            if(movimiento.modoAvion == true)
            {
                puntos = Mathf.Round(puntos + 10 * velGeneral);
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                puntos = Mathf.Round(puntos + 6 * velGeneral);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    IEnumerator contador()
    {
        velGeneral = 30;
        int contar = 0;
        float cambioNivel = 30;
        
        while (destruirNave.alive)
        {
            contar++;
            intervalo = distanciaEntreObstaculos / velGeneral;

            if (GameManager.dificultad == 3)
            {
                intervalo = intervalo / 2;
            }

            else if (GameManager.dificultad == 4)
            {
                intervalo = intervalo / 3;
            }

            else if (GameManager.dificultad == 1)
            {
                intervalo = intervalo * 1.5f;
            }
            
            yield return new WaitForSeconds(1f);

            if (contar >= cambioNivel)
            {
                nivel++;
                contar = 0;
                cambioNivel = cambioNivel * 1.2f;
                
            }
        }
    }

    IEnumerator contadorDeVelocidad()
    {
        while (destruirNave.alive)
        {
            if (nivel < 4)
            {
                yield return new WaitForSeconds(0.00001f);
                velGeneral = velGeneral + 0.12f * Time.deltaTime;
                if (GameManager.dificultad == 4)
                {
                    velGeneral = velGeneral + 0.12f;
                }
            }

            else
            {
                yield return new WaitForSeconds(0.0001f);
                velGeneral = velGeneral + 0.04f * Time.deltaTime;
                if (GameManager.dificultad == 4)
                {
                    velGeneral = velGeneral + 0.04f;
                }
            }
        }
        
    }

    public void MenuOver()
    {
        MenuGameOver.enabled = true;
        BotonPorDefecto.Select();
    }

    public void MenuDesPausar()
    {
        modoPausa = false;
        MenuConfig.enabled = false;
        MenuPausa.enabled = false;
        Time.timeScale = 1 - Time.timeScale;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        BotonDesactivado.Select();
        StartCoroutine("moverse");
    }

    IEnumerator moverse()
    {
        yield return new WaitForSeconds(0.05f);
        movilidad = true;
    }
    
    public void Configurar()
    {
        MenuConfig.enabled = true;
        MenuPausa.enabled = false;
        BotonDeConfig.Select();
    }

    public void DesConfigurar()
    {
        MenuConfig.enabled = false;
        MenuPausa.enabled = true;
        BotonDePausa2.Select();
    }

    public void Pausate()
    {
        if(destruirNave.alive == true)
        {
            if (modoPausa == false)
            {
                Time.timeScale = 1 - Time.timeScale;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;

                movilidad = false;
                modoPausa = true;
                MenuPausa.enabled = true;
                BotonDePausa.Select();
            }

            else if (modoPausa == true)
            {
                movilidad = true;
                MenuDesPausar();
            }
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        vidaSlider.value = destruirNave.vidas;
        gasSlider.value = movimiento.gasolina;
        ShieldSlider.value = destruirNave.cargas;

        puntuacion2.text = Mathf.Round(puntos).ToString() + " ptos";
        puntuacion2.color = Color.white;

        puntuacion.text = Mathf.Round(puntos).ToString() + " ptos";
        puntuacion.color = Color.white;

        nivelador.text ="Nivel " + nivel.ToString();
        nivelador.color = Color.white;

        if (destruirNave.alive == false)
        {
            StopCoroutine("contador");
            StopCoroutine("contadorDePuntos");
            StopCoroutine("contadorDeVelocidad");

            if (puntos > GameManager.highScore)
            {
                GameManager.score3 = GameManager.score2;
                GameManager.score2 = GameManager.highScore;
                GameManager.highScore = puntos;
            }

            else if (puntos < GameManager.highScore && puntos > GameManager.score2)
            {
                GameManager.score3 = GameManager.score2;
                GameManager.score2 = puntos;
            }

            else if (puntos < GameManager.score2 && puntos > GameManager.score3)
            {
                GameManager.score3 = puntos;
            }
        }

        GameManager.dificultad = diffSlider.value;

        if (GameManager.dificultad == 4)
        {
            letrasDif = muyDificil;
        }

        if (GameManager.dificultad == 3)
        {
            letrasDif = dificil;
        }

        if (GameManager.dificultad == 2)
        {
            letrasDif = normal;
        }

        if (GameManager.dificultad == 1)
        {
            letrasDif = facil;
        }

        tipoDeDificultad.text = letrasDif;


    }
}
