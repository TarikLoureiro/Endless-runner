using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
   public GameObject estrada;
    private float contadorTempoestrada=0;

    // Start is called before the first frame update
    void Start()
    {
       Instantiate(estrada, new Vector3(-0.0017561f, -0.0037286f, 5.585f), Quaternion.identity); 
    }

    // Update is called once per frame
    void Update()
    {
        contadorTempoestrada += Time.deltaTime;


        if(contadorTempoestrada	> 3.5f)
        {
            Instantiate(estrada, new Vector3(-0.0017561f, -0.0037286f, 5.585f), Quaternion.identity);


            contadorTempoestrada=0;
        }
        
    }
}
