using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;
using UnityEngine.InputSystem;

namespace aqer
{
    public class Avaliador : MonoBehaviour
    {
        public Controller2 script;
        PlayerControls controls;
        private float acelerador = 0f;
        float tax = 0.03f;
        float tempo = 0f;
        List<float> medidas= new List<float>();
        List<float> tempos = new List<float>();
        List<float> durations = new List<float>();
        float duration = 0f;
        bool entrou = false;
        bool salvo = false;
        string str;

        // Start is called before the first frame update
        private void Awake()
        {
            if(PlayerPrefs.GetInt("nave") == 0)
            {
                gameObject.SetActive(false);
            }
            controls = new PlayerControls();
            controls.Jogar.Acelerar.performed += ctx => acelerador = ctx.ReadValue<float>();
            controls.Jogar.Acelerar.canceled += ctx => acelerador = 0.37f;
        }

        // Update is called once per frame
        void Update()
        {
            if(script.restartado == false)
            {
                salvo = false;
                tempo += Time.deltaTime;
                tax -= Time.deltaTime;
                if(entrou == true)
                {
                    durations.Add(duration);
                    entrou = false;
                }
                if (tax<= 0f)
                {
                    tax = 0.03f;
                }
                if (tax <= 0f && acelerador >= 0.37f)
                {
                    entrou = true;
                    duration += Time.deltaTime;
                    medidas.Add(acelerador);
                    tempos.Add(tempo);
                    tax = 0.03f;
                    
                }
            }
            else
            {
                if(salvo == false)
                {
                    str = "";
                    string str1 = "";
                    string str2 = "";

                    tempo = 0f;
                    tax = 0.03f;
                    string time;
                    time = DateTime.Now.ToString("HH-mm-ss", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                    string date;
                    string data;
                    date = DateTime.UtcNow.ToString("dd-MM-yyyy-");
                    data = @"./Dados/" + date + time + ".txt";

                    //List<KeyValuePair<float, float>> pares = new List<KeyValuePair<float, float>>();
                    List<KeyValuePair<float, float>> pares = Enumerable.Zip(medidas, tempos,(medida, temp) => new KeyValuePair<float, float>(medida, temp)).ToList();

                    StreamWriter arquivo = new StreamWriter(data);

                    foreach (KeyValuePair<float, float> v in pares)
                    {
                        str = str + v.Key.ToString() + "-";
                        str1 = str1 + v.Value.ToString() + "-";
                      
                    }
                    str = str + tempo;
                    float max = 0f;
                    float total = 0f;
                    float[] quantidades = new float[5]; 
                    foreach (float v in medidas)
                    {
                        if (v >= max)
                        {
                            max = v;
                            
                        }
                        if (v > 0.8f && v <= 1f)
                        {
                            quantidades[4] = quantidades[4] + 1f;
                        }
                        if (v > 0.7f && v <= 0.8f)
                        {
                            quantidades[3] = quantidades[3] + 1f;
                        }
                        if (v > 0.6f && v <= 0.7f)
                        {
                            quantidades[2] = quantidades[2] + 1f;
                        }
                        if (v > 0.5f && v <= 0.6f)
                        {
                            quantidades[1] = quantidades[1] + 1f;
                        }
                        if (v > 0.4f && v  <= 0.5f)
                        {
                            quantidades[0] = quantidades[0] + 1f;
                        }
                        total += 1f;
                    }
                    float verif = 0;
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
                        str1 = str1 + "E";
                    }
                    if (categoria == 1)
                    {
                        str1 = str1 + "D";

                    }
                    if (categoria == 2)
                    {
                        str1 = str1 + "C";

                    }
                    if (categoria == 3)
                    {
                        str1 = str1 + "B";

                    }
                    if (categoria == 4)
                    {
                        str1 = str1 + "A";

                    }
                    str1 = str1 + "-" + max.ToString();
                    max = 0f;
                    foreach (float v in durations)
                    {
                        str2 = str2 + v.ToString() + "-";
                        if(v >= max)
                        {
                            max = v;
                        }
                    }
                    str2 = str2 + max.ToString();
                    arquivo.WriteLine(str);
                    arquivo.WriteLine(str1);
                    arquivo.WriteLine(str2);
                    arquivo.Close();
                    salvo = true;
                }
                

            }
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
