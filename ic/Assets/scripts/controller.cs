using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class controller : MonoBehaviour
{
    public Rigidbody2D rb;
    public Slider sliders;
    public Slider sliders2;
    public float speed = 2f;
    private float mantain;
    private float movimentohor;
    public float turn;
    public float virada = 20f;
    public Text aviso;
    public Text gasolina;
    public float combustivel;
    private float lateral = 0f;
    private bool morreu = false;
    private float prespeed;
    float morte = 1.5f;
    PlayerControls controls;
    public bool restartado = false;
    float acelerador, multiplicador, limiar;
    // Start is called before the


    /*namespace Daqread
    {
        public partial class form1: form
        {
            InitializeComponent();
        }
        
    }   */
    void Start()
    {
       /* if(PlayerPrefs.GetString("categoria") == "A")
        {
            modificador = 1f;
        }
        else if(PlayerPrefs.GetString("categoria") == "B")
        {
            modificador = 2f;

        }
        else if(PlayerPrefs.GetString("categoria") == "C")
        {
            modificador = 3f;

        }
        else if(PlayerPrefs.GetString("categoria") == "D")
        {
            modificador = 4f;

        }*/
        mantain = turn;
        sliders.value = 0.38f;
        //turn = turn;
        controls = new PlayerControls();
        controls.Jogar.Right.performed += ctx => RightMove();
        controls.Jogar.Right.canceled += ctx => neutra();
        controls.Jogar.Left.performed += ctx => LeftMove();
        controls.Jogar.Left.canceled += ctx => neutra();
        controls.Jogar.Restart.performed += ctx => restart();
        controls.Jogar.Acelerar.performed += ctx => acelerador = ctx.ReadValue<float>();
        controls.Jogar.Acelerar.canceled += ctx => acelerador = 0.37f;
    }

    // Update is called once per frame
    void Update()
    {
        if (morreu == false)
        {
            /*movimentohor = Input.GetAxis("Horizontal");
            movimentover = Input.GetAxis("Vertical");*/
            lateral += virada * Time.deltaTime * movimentohor;
            rb.velocity = new Vector2(lateral, turn );

            if ( acelerador >= limiar)
            {

                turn += Time.deltaTime * speed;
                combustivel -= Time.deltaTime*40f;
                combustivel = Mathf.Round(combustivel * 100f) / 100f;
                gasolina.text = "Fuel = " + combustivel;
            }
            else
            {
                if(turn > mantain)
                {
                    turn -= Time.deltaTime * speed ;
                }
            }
            if (combustivel <= 0f)
            {
                morreu = true;
                aviso.text = "Errou!!, pressione qualquer tecla para recomeçar.";

            }
            if(turn > 0.1f || turn < -0.1f)
            {
                prespeed = turn;
            }

            transform.position = new Vector2(transform.position.x + virada * Time.deltaTime * movimentohor, transform.position.y);
            // corretores de dificuldade in-game
            limiar = sliders.value;
            multiplicador = sliders2.value;
        }
        else
        {
            morte -= Time.deltaTime;
            if (restartado == true && morte <= 0f)
            {
                FindObjectOfType<platafromapi>().reset();
                transform.position = new Vector2(0f, 150f);
                combustivel = 500f;
                morreu = false;
                gasolina.text = "Fuel = " + 500f;
                aviso.text = "";
                morte = 1.5f;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            else
            {
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
            }
}

    }

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "plataforma")
        {
            morreu = true;
            if (prespeed > -8f)
            {
                aviso.text = "Acertou!! Pressione qualquer tecla para recomeçar.";
            }
            else
            {
                aviso.text = "Impacto forte!! Pressione qualquer tecla para recomeçar.";

            }
        }
        if (collision.gameObject.tag == "chao")
        {
            aviso.text = "Errou!! Pressione qualquer tecla para recomeçar.";
            morreu = true;
        }
       
    }
    /*public double read()
    {
        Task analog = new Task();
        AiChannel canal;
        AiChannel = analog.AiChannels.CreateVoltageChannel("dev1/ai0"),AiTerminalConfiguration.Differential,0,5,"canal",AIvolatgeUnits.volts);
        AnalogSingleChannelReader reader = new AnalogSingleChannelReader(analog.Stream);
        double analogDataIn = reader.ReadSingleSample();
        return analogDataIn;
    }*/
}
