using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrecioComida : MonoBehaviour
{
    public GameObject[] comida;
    public Transform[] position;
    float[] preciosDeLaComida;
    
    public Transform posImportante;


    public Text precioFinal;
    public float precioFin;


    int objetoIni;

    int objetoComplementario;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; 0 < comida.Length - 1; i++)
        {
            preciosDeLaComida[i] = comida[i].GetComponent<PRODUCTO>().precio;
        }

        objetoComplementario = Random.Range(0, comida.Length);
        objetoIni = Random.Range(0, comida.Length - 1);
        posImportante = position[Random.Range(1, position.Length - 1)];
        Instantiate(comida[objetoIni], position[0]);
        Instantiate(comida[objetoComplementario], posImportante);

        for(int i = 1; i<4; i++)
        {
            if(position[i] == posImportante)
            {
                i++;
                Instantiate(comida[objetoComplementario], posImportante);
            }
            else
            {
                Instantiate(comida[Random.Range(0, comida.Length - 1)], position[i]);
            }
        }

        precioFin = comida[objetoComplementario].GetComponent<PRODUCTO>().precio + comida[objetoIni].GetComponent<PRODUCTO>().precio;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

}
