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
    public GameObject canvas;
    public Text noti_text;
    public Text restart_button;

    public GameObject Cosas;

    int resul;
    int valor1;
    int valor2;
    float correct;

    public bool ganar = false;

    int valora;
    int valorb;
    void Start()
    {
        valor1=Instantiate(objetos[Random.Range(0, objetos.Length)], spawnpoint.position, Quaternion.identity).GetComponent<PRODUCTO>().precio;
        textoprecio.text = valor1.ToString() + "$";

        int indexobj = Random.Range(0, objetos.Length);
        valor2 = objetos[indexobj].GetComponent<PRODUCTO>().precio;
        Instantiate(objetos[indexobj], spawnpoint1.position, Quaternion.identity);
        textoproducto1.text = valor2.ToString() + "$";
        
        int a = Random.Range(0, objetos.Length);
        valora= objetos[a].GetComponent<PRODUCTO>().precio;
        Instantiate(objetos[a], spawnpoint2.position, Quaternion.identity);
        textoproducto2.text = valora.ToString() + "$";

        int b = Random.Range(0, objetos.Length);
        valorb = objetos[b].GetComponent<PRODUCTO>().precio;
        Instantiate(objetos[b], spawnpoint3.position, Quaternion.identity);
        textoproducto3.text = valorb.ToString() + "$";

        correct = Random.Range(0.0f, 1.0f);
        resul = valor1 + (correct < 0.5f ? valora : valorb);
        resultado.text = resul.ToString()+"$";

    }

    public void Resultado()
    {
        canvas.SetActive(true);
        if(correct < 0.5f)
        {
            if (toggle2.isOn && !toggle1.isOn && !toggle3.isOn)
            {
                ganar = true;
            }
        }
        else
        {
            if (!toggle2.isOn && !toggle1.isOn && toggle3.isOn)
            {
                ganar = true;
            }
        }
        if(valora == valorb && !toggle1.isOn)
        {
            ganar = true;
        }

        restart_button.text = (ganar ? "reiniciar" : "volve a intentar");
        noti_text.text = (ganar ? "ganaste!" : "perdiste!");
        if(!toggle2.isOn && !toggle1.isOn && !toggle3.isOn)
        {
            restart_button.text = "volver a intentar";
            noti_text.text = "seleccione una opcion";
        }
        Cosas.SetActive(false);
    }

    public void reset()
    {
        if(ganar && !(!toggle2.isOn && !toggle1.isOn && !toggle3.isOn))
        {
            SceneManager.LoadScene("sampleScene");
            ganar = false;
        }
        else
        {
            canvas.SetActive(false);
            Cosas.SetActive(true);
            ganar = false;
            toggle1.isOn = false;
            toggle2.isOn = false;
            toggle3.isOn = false;
        }
    }
}
