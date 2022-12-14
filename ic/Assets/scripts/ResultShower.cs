using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Linq;
//using System.IO;
using System.Runtime.InteropServices;


namespace aqer
{
    public class ResultShower : MonoBehaviour
    {

        public Text max;
        public Text tempo;
        public Text categoria;
        public Slider Acat;
        public Slider Bcat;
        public Slider Ccat;
        public Slider Dcat;
        public Slider Ecat;
        public Text Aval;
        public Text Bval;
        public Text Cval;
        public Text Dval;
        public Text Eval;

        // Start is called before the first frame update
        void Start()
        {
            max.text = "Max = " + PlayerPrefs.GetFloat("Max").ToString("0.00");
            // verificamos o sistema operacional
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //achamos o path
                string homeRoot = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string newFolder = System.IO.Path.Combine(homeRoot, "Dados");

                var directory = new DirectoryInfo(newFolder);
                var myFile = directory.GetFiles()
                             .OrderByDescending(f => f.LastWriteTime)
                             .First();
                Debug.Log(myFile.Name);
                //try.txt e para debug de ultimo arquivo salvo
                StreamWriter arquivo1 = new StreamWriter(newFolder + "/try.txt");

                arquivo1.Write(myFile.Name);
                arquivo1.Close();

                //leitura de arquivo c dados
                StreamReader arquivo = new StreamReader(newFolder + "/" + myFile.Name);
                string tipos = arquivo.ReadLine();
                string[] categorias = tipos.Split('-');
                // subsitituimos os ultimos valores por 0.00 e os ignoramos
                tempo.text = "Tempo = " + categorias[categorias.Length - 2];
                categoria.text = categorias[categorias.Length - 3];
                categorias[categorias.Length - 1] = "0.00";
                categorias[categorias.Length - 2] = "0.00";
                categorias[categorias.Length - 3] = "0.00";

                // colocando em categorias para os sliders
                float[] quantidades = new float[5];
                float total = 0f;
                foreach (string v in categorias)
                {
                    if (float.Parse(v) > 0.8f && float.Parse(v) <= 1f)
                    {
                        quantidades[4] = quantidades[4] + 1f;
                    }
                    if (float.Parse(v) > 0.7f && float.Parse(v) <= 0.8f)
                    {
                        quantidades[3] = quantidades[3] + 1f;
                    }
                    if (float.Parse(v) > 0.6f && float.Parse(v) <= 0.7f)
                    {
                        quantidades[2] = quantidades[2] + 1f;
                    }
                    if (float.Parse(v) > 0.5f && float.Parse(v) <= 0.6f)
                    {
                        quantidades[1] = quantidades[1] + 1f;
                    }
                    if (float.Parse(v) > 0.4f && float.Parse(v) <= 0.5f)
                    {
                        quantidades[0] = quantidades[0] + 1f;
                    }
                    total += 1f;
                }
                // anulamos os 0.00
                total -= 3f;
                // mostramos os resultados
                Acat.value = quantidades[4] / total;
                Aval.text = quantidades[4].ToString();

                Bcat.value = quantidades[3] / total;
                Bval.text = quantidades[3].ToString();

                Ccat.value = quantidades[2] / total;
                Cval.text = quantidades[2].ToString();

                Dcat.value = quantidades[1] / total;
                Dval.text = quantidades[1].ToString();

                Ecat.value = quantidades[0] / total;
                Eval.text = quantidades[0].ToString();
                arquivo.Close();

            }

            else
            {
                // mesma coisa que para linux, porem usamos o @ para achar o path
                var directory = new DirectoryInfo(@".\Dados");
                var myFile = directory.GetFiles()
                             .OrderByDescending(f => f.LastWriteTime)
                             .First();
                Debug.Log(myFile.Name);

                StreamReader arquivo = new StreamReader(myFile.Name);
                string tipos = arquivo.ReadLine();
                string[] categorias = tipos.Split('-');

                tempo.text = "Tempo = " + categorias[categorias.Length - 1];
                categoria.text = categorias[categorias.Length - 2];
                categorias[categorias.Length - 1] = "0.00";
                categorias[categorias.Length - 2] = "0.00";
                categorias[categorias.Length - 3] = "0.00";

                float[] quantidades = new float[5];
                float total = 0f;
                foreach (string v in categorias)
                {
                    if (float.Parse(v) > 0.8f && float.Parse(v) <= 1f)
                    {
                        quantidades[4] = quantidades[4] + 1;
                    }
                    if (float.Parse(v) > 0.7f && float.Parse(v) <= 0.8f)
                    {
                        quantidades[3] = quantidades[3] + 1;
                    }
                    if (float.Parse(v) > 0.6f && float.Parse(v) <= 0.7f)
                    {
                        quantidades[2] = quantidades[2] + 1;
                    }
                    if (float.Parse(v) > 0.5f && float.Parse(v) <= 0.6f)
                    {
                        quantidades[1] = quantidades[1] + 1;
                    }
                    if (float.Parse(v) > 0.4f && float.Parse(v) <= 0.5f)
                    {
                        quantidades[0] = quantidades[0] + 1;
                    }
                    total += 1f;
                }
                total -= 3f;
                Acat.value = quantidades[4] / total;
                Aval.text = quantidades[4].ToString();

                Bcat.value = quantidades[3] / total;
                Bval.text = quantidades[3].ToString();

                Ccat.value = quantidades[2] / total;
                Cval.text = quantidades[2].ToString();

                Dcat.value = quantidades[1] / total;
                Dval.text = quantidades[1].ToString();

                Ecat.value = quantidades[0] / total;
                Eval.text = quantidades[0].ToString();
                arquivo.Close();

            }
            
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
