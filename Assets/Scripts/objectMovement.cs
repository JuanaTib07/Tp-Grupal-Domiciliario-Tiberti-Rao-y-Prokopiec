using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectMovement : MonoBehaviour
{
    public float frequency = 2;
    public float amplitude = 10;
    public float rotation_speed = 3;
    float random_offset;
    // Start is called before the first frame update
    void Start()
    {
        random_offset = Random.Range(0.0f, 50.0f);
        transform.Rotate(new Vector3(0, Random.Range(0.0f, 360.0f), 0));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, Mathf.Sin(Time.fixedTime*frequency+random_offset)*Time.deltaTime*amplitude, 0));
        transform.Rotate(new Vector3(0, rotation_speed * Time.deltaTime, 0));
    }
}
