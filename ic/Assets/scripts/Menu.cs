using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.IO;
using System;
using System.Globalization;

public class Menu : MonoBehaviour
{

    public Text sensor;
    PlayerControls controls;
    public float acelerador = 0f;
    public Text testado;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Testado") != 1)
        {
            testado.text = "Você ainda não fez o teste.";
        }
        else
        {
            testado.text = "";
        }

        controls = new PlayerControls();
        controls.Jogar.Acelerar.performed += ctx => acelerador = ctx.ReadValue<float>();
        controls.Jogar.Acelerar.canceled += ctx => acelerador = 0.37f;
        if (!Directory.Exists(@".\Dados"))
        {
            Directory.CreateDirectory(@".\Dados");
            Debug.Log("aa");
        }


        // teste 
        /*string time;
        time = DateTime.Now.ToString("HH-mm-ss", System.Globalization.DateTimeFormatInfo.InvariantInfo);
        string date;
        string data;
        date = DateTime.UtcNow.ToString("dd-MM-yyyy-");
        data = @"./Dados/"+ date + time  + ".txt";
        //Passa a file que será armazenado
        StreamWriter arquivo = new StreamWriter(data);
        arquivo.WriteLine("A-A");
        arquivo.WriteLine(date);
        arquivo.WriteLine(time);
        arquivo.Close();*/
    }

    // Update is called once per frame
    void Update()
    {
        sensor.text = "limiar = " + acelerador.ToString("0.00"); 
    }

    public void Type1()
    {
        PlayerPrefs.SetInt("nave", 0);
        SceneManager.LoadScene(1);

    }
    public void Type2()
    {
        PlayerPrefs.SetInt("nave", 1);
        SceneManager.LoadScene(1);

    }
    public void QuitGame()
    {
        Debug.Log("saiu");
        Application.Quit();
    }
    public void Teste()
    {
        SceneManager.LoadScene(2);
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
