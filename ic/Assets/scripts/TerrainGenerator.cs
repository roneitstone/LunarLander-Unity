using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class TerrainGenerator : MonoBehaviour
{
    private LineRenderer line;
    private EdgeCollider2D colisao;
    //private Vector2 ponto;
    private Vector2 LateraisTela;
    private int count = 0;
    private float v, vcumulativo;
    //private List<Vector2> pontos;
    private Vector2 LateralAnt;

    // Start is called before the first frame update
    
    void Start()
    {
        line = FindObjectOfType<LineRenderer>();
        colisao = GameObject.Find("Line").GetComponent<EdgeCollider2D>();
        // pega as propoções da tela
        LateraisTela = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        // fraciona o tamnha em 8 partes para gerar o terreno 
        v = LateraisTela.x/8;
        Debug.Log(LateraisTela.x);

        // constante de distancia entre pontos do linerenderer
        vcumulativo = -LateraisTela.x + v;
        line.positionCount = 1;

        // setamos o primeiro ponto
        line.SetPosition(0, new Vector3(-LateraisTela.x, 0f ,0f));
       
    }

    // Update is called once per frame
    void Update()
    {
        // aumentamos o tamanho da tela para poder gerar novos terrenos
        LateralAnt = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        if (LateraisTela != LateralAnt)
        {
            LateraisTela = LateralAnt;
        }
        Vector3 pos = Vector3.zero;
        pos.x = vcumulativo;

        // pegamos a proporção da tela e aumentamos um pouco a geração para evitar partes sem terreno
        if(vcumulativo <= LateralAnt.x+70f)
        {
            count += 1;
            line.positionCount += 1;
            // variamos a distancia em x para os pontos e para y
            pos.y = Random.Range(LateraisTela.y / -1.4f,3f);
            vcumulativo += v + Random.Range(0f, 2*v);
            line.SetPosition(count, pos);
            // geramos o colisor
            SetCollider(line);
            
        }
        else
        {

        }
        

    }

    // colocamos a colisao do edge collider para todos os pontos do linerenderer
    void SetCollider(LineRenderer liner)
    {
        List<Vector2> pontos = new List<Vector2>();
        for (int ponto = 0; ponto < liner.positionCount; ponto++)
        {
            Vector3 linepontos = liner.GetPosition(ponto);
            pontos.Add(new Vector2(linepontos.x, linepontos.y));
        }
        colisao.SetPoints(pontos);
    }
}
