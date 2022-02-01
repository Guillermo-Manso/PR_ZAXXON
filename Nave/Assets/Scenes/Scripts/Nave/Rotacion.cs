using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    InputManager inputManager;

    Vector2 joyIzqdo;


    public GameObject Nave;
    private Movimiento movimiento;

    private void Awake()
    {
        inputManager = new InputManager();

        inputManager.Hola.MoverNave.performed += a => joyIzqdo = a.ReadValue<Vector2>();
        inputManager.Hola.MoverNave.canceled += a => joyIzqdo = Vector2.zero;
    }
        // Start is called before the first frame update
        void Start()
    {
        movimiento = GameObject.Find("Nave").GetComponent<Movimiento>();
    }
    void Update()
    {
        if (movimiento.transform.position.y >= -1.308465f)
        {
            transform.rotation = Quaternion.Euler(-30 * joyIzqdo.y, 0, -30 * joyIzqdo.x);
        }

        else if(movimiento.transform.position.y == -2.88f)
        {
            transform.rotation = Quaternion.Euler(0, 30 * joyIzqdo.x, 0);
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
