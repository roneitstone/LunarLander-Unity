using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limitador : MonoBehaviour
{
    private Vector2 LateraisTela;
    private Vector2 LateralAnt;
    public float AltObj;
    public float LargObj;

    // Start is called before the first frame update
    void Start()
    {
        // pega as proporçoes da tela
        LateraisTela = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        LateralAnt = LateraisTela;
        // pega as dimensões do player
        AltObj = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        LargObj = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // limita a movimenttação horizontal a esquerda e a movimentação vertical
        LateralAnt = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, LateraisTela.x * -1 + LargObj, LateraisTela.x - LargObj), Mathf.Clamp(transform.position.y, LateraisTela.y * -1 + AltObj, LateraisTela.y - AltObj), transform.position.z);
        if(LateraisTela != LateralAnt)
        {
            LateraisTela= LateralAnt;
        }
    }
}
