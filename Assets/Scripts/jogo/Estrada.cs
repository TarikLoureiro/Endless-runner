using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Estrada : MonoBehaviour
{
    public GameObject estrada;


    private float velocidadecenario = 0.0015f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        estrada.transform.Translate(0, 0, velocidadecenario * -1);
        if(gameObject.transform.position.z<-4.473434f)
        {
            Destroy(gameObject);
        }
    }
}
