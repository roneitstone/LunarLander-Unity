using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


namespace aqer
{
    public class Dialogodinamicoteste : MonoBehaviour
    {
        public TextWriter textWriter;
        public Text fala;
        
        public float delay = 0.025f;
        // Start is called before the first frame update
        void Start()
        {
            textWriter.AddWriter(fala, "Bem vindo ao sistema de avalia��o do jogador.\n\n\n Assim que voc� clicar em Play, assopre o controllador da maneira mais forte e consistente que voc� conseguir. \n\nD� o seu melhor nobre astronauta.", delay, true);

        }

        // Update is called once per frame
        void Update()
        {

          

        }
    }
}