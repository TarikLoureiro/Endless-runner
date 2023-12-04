using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawns : MonoBehaviour
{
    public GameObject estrada;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(estrada, new Vector3(-0.0017561f, -0.0037286f, 5.585f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
