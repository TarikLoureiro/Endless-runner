using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public float velocidade;
    public float velocidadeLinha;
    public float tamanhoSalto;
    public float alturaSalto;
    public float tamanhoEscorrega;


    private Animator animacao;
    private Rigidbody rb;
    private BoxCollider boxCollider;
    private int currentLane = 1;
    private Vector3 verticalTargetPosition;
    private bool saltar = false;
    private float inicioSalto;
    private bool escorregar = false;
    private float inicioEscorregar;
    private Vector3 boxColliderSize;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //animacao = GetComponentInChildren<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        boxColliderSize = boxCollider.size;
    }
 
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MudancaLinha(-1);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            MudancaLinha(1);
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Salto();
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Baixar();
        }

        if(saltar)
        {
            float racio = (transform.position.z - inicioSalto) / tamanhoSalto;
            if(racio >= 1f)
            {
                saltar = false;
                //animacao.SetBool("Saltar", false)
            }
            else
            {
                verticalTargetPosition.y = Mathf.Sin(racio * Mathf.PI) * alturaSalto;
            }
        }
        else
        {
            verticalTargetPosition.y = Mathf.MoveTowards(verticalTargetPosition.y, 0, 5 * Time.deltaTime);
        }

        if(escorregar)
        {
            float racio = (transform.position.z - inicioEscorregar) / tamanhoEscorrega;
            if(racio >= 1f)
            {
                escorregar = false;
                //animacao.SetBool("Baixar", false)
                boxCollider.size = boxColliderSize;
            }
        }

        Vector3 targetPosition = new Vector3(verticalTargetPosition.x, verticalTargetPosition.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, velocidadeLinha * Time.deltaTime);
    }


    private void FixedUpdate()
    {
        rb.velocity = Vector3.forward * velocidade;
    }

    void MudancaLinha(int direcao)
    {
        int targetLane = currentLane + direcao;
        if(targetLane < 0 || targetLane > 2)
        return;
        currentLane = targetLane;
        verticalTargetPosition = new Vector3((currentLane -1),0,0);
    }

    void Salto()
    {
        if(!saltar)
        {
            inicioSalto = transform.position.z;
            //animacao.SetFloat("VelocidadeSalto", velocidade / tamanhoSalto);
            //animacao.SetBool("Saltar", true);
            saltar = true;
        }
    }

    void Baixar()
    {
        if(!saltar && !escorregar)
        {
            inicioEscorregar = transform.position.z;
            //animacao.SetFloat("VelocidadeSalto", velocidade / tamanhoEscorrega);
            //animacao.SetBool("Escorregar", true);
            Vector3 newSize = boxCollider.size;
            newSize.y = newSize.y / 2;
            boxCollider.size = newSize;
            escorregar = true;
        }
    }
}
