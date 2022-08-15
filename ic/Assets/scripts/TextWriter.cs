using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private Text dialogo;
    private string textToWrite;
    private float TimePerCharacter;
    private float timer;
    private int characterIndex;
    private bool invisibleChar;

    public void AddWriter(Text dialogo, string textToWrite, float TimePerCharacter, bool invisibleChar)
    {
        this.dialogo = dialogo;
        this.textToWrite = textToWrite;
        this.TimePerCharacter = TimePerCharacter;
        this.invisibleChar = invisibleChar;
        characterIndex = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogo != null)
        {
            timer -= Time.deltaTime;
            while(timer <= 0f)
            {
                timer += TimePerCharacter;
                characterIndex++;
                string text = textToWrite.Substring(0, characterIndex);
                if (invisibleChar)
                {
                    text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                }
                dialogo.text = text;

                if(characterIndex >= textToWrite.Length)
                {
                    dialogo = null;
                    return;
                }
            }
            

        }
    }
}
