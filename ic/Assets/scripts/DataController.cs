using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace aqer
{
    public class DataController : MonoBehaviour
    {
        public Dropdown dropdown;
        public Text max;
        public Text tempo;
        public Text categoria;
        public Text intermitente;
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
        private FileInfo[] File;
        

        // Start is called before the first frame update
        void Start()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                string homeRoot = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string newFolder = System.IO.Path.Combine(homeRoot, "Dados");
                var directory = new DirectoryInfo(newFolder);
                FileInfo[] Files = directory.GetFiles("*.txt"); //Getting Text files
                string str = "";
                int contador = 0;
                foreach (FileInfo file in Files)
                {
                    if (contador < Files.Length - 1)
                    {
                        str = str + file.Name + ",";

                    }
                    else
                    {
                        str = str + file.Name;

                    }
                    contador += 1;
                }
                Debug.Log(str);
                string[] arquivos = str.Split(',');
                dropdown.options.Clear();

                List<string> items = new List<string>();

                foreach (string name in arquivos)
                {
                    items.Add(name);
                }

                foreach (var item in items)
                {
                    dropdown.options.Add(new Dropdown.OptionData() { text = item });
                }

                DropdownItemSelected(dropdown);

                dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });
            }

            else
            {
                var directory = new DirectoryInfo(@".\Dados");
                FileInfo[] Files = directory.GetFiles("*.txt"); //Getting Text files
                string str = "";
                int contador = 0;
                foreach (FileInfo file in Files)
                {
                    if (contador < Files.Length - 1)
                    {
                        str = str + file.Name + ",";

                    }
                    else
                    {
                        str = str + file.Name;

                    }
                    contador += 1;
                }
                Debug.Log(str);
                string[] arquivos = str.Split(',');
                dropdown.options.Clear();

                List<string> items = new List<string>();

                foreach (string name in arquivos)
                {
                    items.Add(name);
                }

                foreach (var item in items)
                {
                    dropdown.options.Add(new Dropdown.OptionData() { text = item });
                }

                DropdownItemSelected(dropdown);

                dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });
            }


        
          
 
               
        }
        void DropdownItemSelected(Dropdown dropdown)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                string homeRoot = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string newFolder = System.IO.Path.Combine(homeRoot, "Dados/");
                int index = dropdown.value;
                string data = newFolder + dropdown.options[index].text;

                StreamReader arquivo = new StreamReader(data);

                string valor = arquivo.ReadLine();
                string[] dados = valor.Split('-');

                tempo.text = "tempo = " + dados[dados.Length - 2];
                categoria.text = dados[dados.Length - 3];
                intermitente.text = "Intermitente = " + dados[dados.Length - 1];
                dados[dados.Length - 1] = "0.00";
                dados[dados.Length - 2] = "0.00";
                dados[dados.Length - 3] = "0.00";

                arquivo.Close();

                float[] quantidades = new float[5];
                float total = 0;
                float maxI = 0;
                foreach (string v in dados)
                {
                    if (float.Parse(v) >= maxI)
                    {
                        maxI = float.Parse(v);
                        max.text = "Max = " + maxI.ToString();
                    }
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
                total -= 3;
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
                //TextBox.text = dropdown.options[index].text;
            }
            else
            {
                int index = dropdown.value;
                string data = @"./Dados/" + dropdown.options[index].text;
                Debug.Log("IU");
                StreamReader arquivo = new StreamReader(data);

                string valor = arquivo.ReadLine();
                string[] dados = valor.Split('-');

                tempo.text = "tempo = " + dados[dados.Length - 2];
                categoria.text = dados[dados.Length - 3];
                intermitente.text = "Intermitente = " + dados[dados.Length - 1];
                dados[dados.Length - 1] = "0.00";
                dados[dados.Length - 2] = "0.00";
                dados[dados.Length - 3] = "0.00";

                arquivo.Close();

                float[] quantidades = new float[5];
                float total = 0;
                float maxI = 0;
                foreach (string v in dados)
                {
                    if (float.Parse(v) >= maxI)
                    {
                        maxI = float.Parse(v);
                        max.text = "Max = " + maxI.ToString();
                    }
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
                total -= 3;
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
                //TextBox.text = dropdown.options[index].text;
            }

        }


        
        
    }
}
