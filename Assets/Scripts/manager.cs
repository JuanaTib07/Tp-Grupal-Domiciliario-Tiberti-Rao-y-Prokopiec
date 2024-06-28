using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class manager : MonoBehaviour
{
    public Transform spawnpoint;

    public Transform spawnpoint1;
    public Transform spawnpoint2;
    public Transform spawnpoint3;

    public Text textoprecio;

    public Text textoproducto1;
    public Text textoproducto2;
    public Text textoproducto3;

    public Text resultado;

    public Toggle toggle1;
    public Toggle toggle2;
    public Toggle toggle3;

    public GameObject[] objetos;

    int resul;
    int valor1;
    int valor2;
    float correct;

    public bool ganar = false;

    void Start()
    {
        valor1=Instantiate(objetos[Random.Range(0, objetos.Length)], spawnpoint.position, Quaternion.identity).GetComponent<PRODUCTO>().precio;
        textoprecio.text = valor1.ToString() + "$";

        int indexobj = Random.Range(0, objetos.Length);
        valor2 = objetos[indexobj].GetComponent<PRODUCTO>().precio;
        Instantiate(objetos[indexobj], spawnpoint1.position, Quaternion.identity);
        textoproducto1.text = valor2.ToString() + "$";
        
        int a = Random.Range(0, objetos.Length);
        int valora= objetos[a].GetComponent<PRODUCTO>().precio;
        Instantiate(objetos[a], spawnpoint2.position, Quaternion.identity);
        textoproducto2.text = valora.ToString() + "$";

        int b = Random.Range(0, objetos.Length);
        int valorb = objetos[b].GetComponent<PRODUCTO>().precio;
        Instantiate(objetos[b], spawnpoint3.position, Quaternion.identity);
        textoproducto3.text = valorb.ToString() + "$";

        correct = Random.Range(0.0f, 1.0f);
        resul = valor1 + (correct < 0.5f ? valora : valorb);
        resultado.text = resul.ToString()+"$";

    }

    public void Resultado()
    {
        if(correct < 0.5f)
        {
            if (toggle2.isOn && !toggle1.isOn && !toggle3.isOn)
            {
                ganar = true;
            }
            else
            {
                SceneManager.LoadScene("sampleScene");
            }
        }
        else
        {
            if (!toggle2.isOn && !toggle1.isOn && toggle3.isOn)
            {
                ganar = true;
            }
            else
            {
                SceneManager.LoadScene("sampleScene");
            }
        }
    }
}
