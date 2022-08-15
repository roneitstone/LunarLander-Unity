using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace aqer
{
   
    public class ShowValue : MonoBehaviour
    {
        public float barra;
        public Text valor;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            barra = gameObject.GetComponent<Slider>().value;
            valor.text = barra.ToString();
        }
    }
}
