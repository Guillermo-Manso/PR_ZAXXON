using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntuacion : MonoBehaviour
{
    public Text highscore;
    public Text score2;
    public Text score3;

    float puntos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        highscore.text = Mathf.Round(GameManager.highScore).ToString();
        score2.text = Mathf.Round(GameManager.score2).ToString();
        score3.text = Mathf.Round(GameManager.score3).ToString();
    }
}
