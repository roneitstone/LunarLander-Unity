using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Linq;


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
            //tempo.text += PlayerPrefs.GetFloat("Tempo");
            //categoria.text += PlayerPrefs.GetFloat("Categoria");
            var directory = new DirectoryInfo(@".\Dados");
            var myFile = directory.GetFiles()
                         .OrderByDescending(f => f.LastWriteTime)
                         .First();
            Debug.Log(myFile.Name);

            StreamReader arquivo = new StreamReader(myFile.Name);
            string tipos = arquivo.ReadLine();
            string[] categorias = tipos.Split('-');

            tempo.text = "Tempo = " + categorias[categorias.Length - 1 ];
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

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
