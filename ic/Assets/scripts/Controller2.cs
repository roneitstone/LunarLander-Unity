using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Controller2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool restartado = false;
    public float speed = 2f;
    private float mantain, multiplicador, acelerador;
    public float movimentohor;
    public float turn;
    public float virada = 20f;
    public Text aviso;
    public Text gasolina;
    public float combustivel;
    public float limiar;
    public Slider sliders;
    public Slider sliders2;
    private float lateral = 90f;
    private bool morreu = false;
    float morte = 1.5f;
    Vector2 movement;
    private double prespeed;
    Quaternion rotacao;
    PlayerControls controls;

    // Start is called before the first frame update
    private void Awake()
    {
        mantain = speed;

        controls = new PlayerControls();
        controls.Jogar.Right.performed += ctx => RightMove();
        controls.Jogar.Right.canceled += ctx => neutra();
        controls.Jogar.Left.performed += ctx => LeftMove();
        controls.Jogar.Left.canceled += ctx => neutra();
        controls.Jogar.Restart.performed += ctx => restart();
        controls.Jogar.Acelerar.performed += ctx => acelerador = ctx.ReadValue<float>();
        controls.Jogar.Acelerar.canceled += ctx => acelerador = 0.37f ;
    }
   void Start()
    {
        limiar = acelerador + 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (morreu == false)
        {
           
            lateral += virada * Time.deltaTime * -movimentohor;

            // movimentacao por vetorização de eixo
            movement = new Vector2(turn * Mathf.Cos(lateral / Mathf.Rad2Deg), turn * Mathf.Sin(lateral / Mathf.Rad2Deg));
            movement.Normalize();

            // modificar os eixos do vetor
            if (movement != Vector2.zero)
            {
                rotacao = Quaternion.LookRotation(Vector3.forward, movement);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacao, virada * Time.deltaTime);
            }
            
            // aumentar o valor do vetor 
            if (acelerador >= limiar)
            {
                    combustivel -= Time.deltaTime * 40f;
                    combustivel = Mathf.Round(combustivel * 100f) / 100f;
                    gasolina.text = "Fuel = " + combustivel;
                    speed += Time.deltaTime * acelerador*120*multiplicador;
                    rb.AddForce(transform.up * speed);
            }
                
            // simulação da gravidade
            else
            {
                if (speed > mantain)
                {
                    speed -= Time.deltaTime * 100;
                }
            }


            // zera a velocidade do rigid body apos restart
            if (rb.velocity.y < -0.4f || rb.velocity.y > 0.4f)
            {
                prespeed = rb.velocity.y;
            }

            // detecta falta de combustível
            if (combustivel <= 0f)
            {
                morreu = true;
                aviso.text = "Errou!!, pressione qualquer tecla para recomeçar.";

            }
        }
        // sistema de restart
        else
        {
            morte -= Time.deltaTime;
            if (restartado == true)
            {
                restartado = false;
                FindObjectOfType<platafromapi>().reset();
                transform.position = new Vector2(0f, 150f);
                combustivel = 500f;
                morreu = false;
                gasolina.text = "Fuel = " + 500f;
                aviso.text = "";
                morte = 1.5f;
                rb.constraints = RigidbodyConstraints2D.None;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                rb.velocity = new Vector2(0, 0);
                lateral = 90f;
            }   
            else
            {
                restartado = false;
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;

            }
        }
        // corretores de dificuldade in-game
        limiar = sliders.value;
        multiplicador = sliders2.value;
    }
    
    // funcao de neutralizar movimentzaçao
    void restart()
    {
        if (restartado == false)
        {
            restartado = true;

        }
    }
  
    void neutra()
    {
        movimentohor = 0f;
    }

    // funcao de movimentar a direita
    void RightMove()
    {
        movimentohor = 1f;
    }

    // funcao de movimentar a esquerda
    void LeftMove()
    {
        movimentohor = -1f;
    }

    private void OnEnable()
    {
        controls.Jogar.Enable();
    }

    private void OnDisable()
    {
        controls.Jogar.Disable();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "plataforma")
        {
            morreu = true;
            if (prespeed > -12)
            {
                aviso.text = "Acertou!! Pressione qualquer tecla para recomeçar.";
            }
            else
            {
                aviso.text = "Impacto forte!! Pressione qualquer tecla para recomeçar.";
            }
            Debug.Log(prespeed);
        }
        if (collision.gameObject.tag == "chao")
        {
            aviso.text = "Errou!!, pressione qualquer tecla para recomeçar.";
            morreu = true;
        }

    }
}
