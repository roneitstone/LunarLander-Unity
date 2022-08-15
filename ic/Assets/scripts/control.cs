using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 2f;
    private float mantain;
    private float movimentohor;
    private float movimentover;
    public float turn;
    public float virada = 20f;
    public Text aviso;
    public Text gasolina;
    public float combustivel;
    private float lateral = 0f;
    private bool morreu = false;
    private float prespeed;
    float morte = 1.5f;
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

        mantain = -turn;
        turn = -turn;
    }

    // Update is called once per frame
    void Update()
    {
        if (morreu == false)
        {
            movimentohor = Input.GetAxis("Horizontal");
            movimentover = Input.GetAxis("Vertical");
            lateral += virada * Time.deltaTime * movimentohor;
            rb.velocity = new Vector2(lateral, turn);

            if (movimentover > 0)
            {

                turn += Time.deltaTime * speed;
                combustivel -= Time.deltaTime * 40f;
                combustivel = Mathf.Round(combustivel * 100f) / 100f;
                gasolina.text = "Fuel = " + combustivel;
            }
            else
            {
                if (turn > mantain)
                {
                    turn -= Time.deltaTime * speed;
                }
            }
            if (combustivel <= 0f)
            {
                morreu = true;
                aviso.text = "Errou!!, pressione qualquer tecla para recomeçar.";

            }
            if (turn > 0.1f || turn < -0.1f)
            {
                prespeed = turn;
            }

            transform.position = new Vector2(transform.position.x + virada * Time.deltaTime * movimentohor, transform.position.y);
        }
        else
        {
            morte -= Time.deltaTime;
            if (Input.anyKey && morte <= 0f)
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

