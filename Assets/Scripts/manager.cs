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

    public GameObject[] objetos;

    int resul;
    int valor1;
    int valor2;
    void Start()
    {
        valor1=Instantiate(objetos[Random.Range(0, objetos.Length)], spawnpoint.position, Quaternion.identity).GetComponent<PRODUCTO>().precio;
        
        int indexobj = Random.Range(0, objetos.Length);
        valor2 = objetos[indexobj].GetComponent<PRODUCTO>().precio;
        Instantiate(objetos[indexobj], spawnpoint1.position, Quaternion.identity);
        textoproducto1.text = valor2.ToString() + "$";

        resul = valor2 + valor1;


        textoprecio.text = resul.ToString();
        
        int a = Random.Range(0, objetos.Length);
        int valora= objetos[a].GetComponent<PRODUCTO>().precio;
        Instantiate(objetos[a], spawnpoint2.position, Quaternion.identity);
        textoproducto2.text = valora.ToString() + "$";

        int b = Random.Range(0, objetos.Length);
        int valorb = objetos[b].GetComponent<PRODUCTO>().precio;
        Instantiate(objetos[b], spawnpoint3.position, Quaternion.identity);
        textoproducto2.text = b.ToString() + "$";



    }
}
