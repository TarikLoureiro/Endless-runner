using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condutor : MonoBehaviour
{
     private float limitePosicional = 0.343f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            if(gameObject.transform.position.x < 0.34f)
            {
                gameObject.transform.Translate(0.343f, 0, 0);
            }  
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            if(gameObject.transform.position.x > -0.325f)
            {
                gameObject.transform.Translate(-0.325f, 0, 0);
            }  
        }

    }
}
