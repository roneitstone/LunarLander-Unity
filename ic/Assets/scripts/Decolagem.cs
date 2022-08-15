using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.IO;
using System;
using System.Globalization;




using System.Linq;

namespace aqer
{

    public class Decolagem : MonoBehaviour
    {
        public Text tempo;
        public Text limiar;
        //public Slider slider;
        int[] quantidades = new int[5];
        List<float> valor = new List<float>();
        private float acelerador = 0f;
        public float average;
        public float delay = 0f;
        private float simulation = 0.05f;
        float max = 0f;
        private bool started = false;
        bool entrou = false;
        PlayerControls controls;
        public GameObject resultados;
        public Rigidbody2D rb;
        // Start is called before the first frame update
        private void Awake()
        {
            controls = new PlayerControls();
            controls.Jogar.Acelerar.performed += ctx => acelerador = ctx.ReadValue<float>();
            controls.Jogar.Acelerar.canceled += ctx => acelerador = 0.37f;
        }
        void Start()
        {
            //slider.value = 0.0f;
            PlayerPrefs.SetInt("Testado", 1);
           
            
            
            
        }

        // Update is called once per frame
        void Update()
        {
            
            if (acelerador < 0.4f && entrou == true)
            {
                started = true;
                entrou = false;
                listador();
                rb.AddForce(transform.up * 40f);

            }
            if (acelerador > 0.4f && started == false)
            {
                delay += Time.deltaTime;
                rb.AddForce(transform.up * 23f * acelerador);
                
                limiar.text = acelerador.ToString();
                tempo.text = delay.ToString();

                simulation -= Time.deltaTime;
                if (simulation <= 0)
                {
                    if (max < acelerador)
                    {
                        max = acelerador;
                    }

                    entrou = true;
                    valor.Add(acelerador);
                    simulation = 0.05f;
                }

            }
        }
        public void listador()
        {
            // setando a maxima encontrada na analise
            PlayerPrefs.SetFloat("Max", max);

            foreach (float v in valor)
            {
                if (v > 0.8f && v <= 1f)
                {
                    quantidades[4] = quantidades[4] + 1;
                }
                if (v > 0.7f && v <= 0.8f)
                {
                    quantidades[3] = quantidades[3] + 1;
                }
                if (v > 0.6f && v <= 0.7f)
                {
                    quantidades[2] = quantidades[2] + 1;
                }
                if (v > 0.5f && v <= 0.6f)
                {
                    quantidades[1] = quantidades[1] + 1;
                }
                if (v > 0.4f && v <= 0.5f)
                {
                    quantidades[0] = quantidades[0] + 1;
                }
            }
            int verif = 0;
            int categoria = 0;
            for (int i = 0; i < 5; i++)
            {
                if (quantidades[i] >= verif)
                {
                    verif = quantidades[i];
                    categoria = i;
                }
            }
            if (categoria == 0)
            {
                PlayerPrefs.SetString("Categoria", "E");
            }
            if (categoria == 1)
            {
                PlayerPrefs.SetString("Categoria", "D");

            }
            if (categoria == 2)
            {
                PlayerPrefs.SetString("Categoria", "C");

            }
            if (categoria == 3)
            {
                PlayerPrefs.SetString("Categoria", "B");

            }
            if (categoria == 4)
            {
                PlayerPrefs.SetString("Categoria", "A");

            }
            PlayerPrefs.SetFloat("Tempo", delay);
            Arquivador();
        }

        private void Arquivador()
        {
          
            string str = "";
            string time;
            time = DateTime.Now.ToString("HH-mm-ss", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            string date;
            string data;
            date = DateTime.UtcNow.ToString("dd-MM-yyyy-");
            data = @"./Dados/" + date + time + ".txt";
            //Passa a file que será armazenado
            StreamWriter arquivo = new StreamWriter(data);
                foreach(float v in valor)
                {
                    str = str + v.ToString("0.00") + "-";
                }
            str = str + PlayerPrefs.GetString("Categoria") + "-" + PlayerPrefs.GetFloat("Tempo").ToString("0.00") + "-" + "NA";
            arquivo.Write(str);
            arquivo.Close();
            resultados.SetActive(true);
            gameObject.SetActive(false);
            
        }
        private void OnEnable()
        {
            controls.Jogar.Enable();
        }

        private void OnDisable()
        {
            controls.Jogar.Disable();
        }
    }

}