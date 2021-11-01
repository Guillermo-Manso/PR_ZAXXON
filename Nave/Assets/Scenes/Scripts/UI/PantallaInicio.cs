using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaInicio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Jugar()
    {
        SceneManager.LoadScene(1);
    }

}
