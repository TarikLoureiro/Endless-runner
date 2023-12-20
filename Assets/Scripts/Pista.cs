using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pista : MonoBehaviour
{

    public GameObject[] obstaculos;
    public Vector2 numeroObstaculos;

    public List<GameObject> novoObstaculo;

    // Start is called before the first frame update
    void Start()
    {
        int novoNumeroObstaculos = (int)Random.Range(numeroObstaculos.x, numeroObstaculos.y);

        for (int i = 0; i < novoNumeroObstaculos; i++)
        {
            novoObstaculo.Add(Instantiate(obstaculos[Random.Range(0, obstaculos.Length)], transform));
            novoObstaculo[i].SetActive(false);
        }

        PosicionamentoObstaculos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PosicionamentoObstaculos()
    {
         for (int i = 0; i < novoObstaculo.Count; i++)
        {
            float posZMin = (23.412f / novoObstaculo.Count) + (23.412f / novoObstaculo.Count) * i;
            float posZMax = (23.412f / novoObstaculo.Count) + (23.412f / novoObstaculo.Count) * i + 1;
            novoObstaculo[i].transform.localPosition = new Vector3(0, 0, Random.Range(posZMin, posZMax));
            novoObstaculo[i].SetActive(true);
        }
    }
}
