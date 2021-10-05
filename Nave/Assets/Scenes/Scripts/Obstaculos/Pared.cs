using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pared : MonoBehaviour
{
    [SerializeField] GameObject esfera;
    [SerializeField] GameObject ladrillo;
    [SerializeField] GameObject pinchoIzqda;
    [SerializeField] Transform initPos;
    
    

    // Start is called before the first frame update
    void Start()
    {

            StartCoroutine("Pareddes");
            StartCoroutine("Paredes");
            StartCoroutine("PinchoIzqda");


    }

    IEnumerator Pareddes()
    {
        


        for (int n = 0; ; n++)
        {
            float aleatorioX = Random.Range(-13, 13);
            float aleatorioY = Random.Range(-2.34f, 20);

            Vector3 newPos = new Vector3(aleatorioX, aleatorioY, transform.position.z);



            Instantiate(ladrillo, newPos, Quaternion.identity);

            yield return new WaitForSeconds(0.3f);
        }

        

    }

    IEnumerator Paredes()
    {



        for (int n = 0; ; n++)
        {
            float aleatorioX = Random.Range(-13, 13);
            float aleatorioY = Random.Range(-2.34f, 20);

            Vector3 newPos = new Vector3(aleatorioX, aleatorioY, transform.position.z);



            Instantiate(esfera, newPos, Quaternion.identity);

            yield return new WaitForSeconds(0.3f);
        }



    }


    IEnumerator PinchoIzqda()
    {



        for (int n = 0; ; n++)
        {
            float aleatorioX = Random.Range(-13, 13);

            Vector3 newPos = new Vector3(aleatorioX, transform.position.y, transform.position.z);



            Instantiate(pinchoIzqda, newPos, Quaternion.Euler(0,0,20));
            Instantiate(pinchoIzqda, newPos, Quaternion.Euler(0, 0, -20));

            yield return new WaitForSeconds(0.7f);
        }





    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
