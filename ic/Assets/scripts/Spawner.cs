using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Vector2 LateraisTela;
    private Vector2 LateralAnt;
    public GameObject prefab;
    float dist;
    // Start is called before the first frame update
    void Start()
    {
        // pega as proporçoes da tela
        LateraisTela = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        //gera a primeira plataforma
        Instantiate(prefab, new Vector3(Random.Range(LateraisTela.x * -1, LateraisTela.x), 46f, 0f), Quaternion.identity);
        dist = LateraisTela.x;


    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<Controller2>().restartado == false)
        {


            // aumenta as proporções da tela para a movimentação
            LateralAnt = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            if (LateraisTela != LateralAnt)
            {
                LateraisTela = LateralAnt;
            }

            // verifica se plataforma despawnou e respawna novamente
            if (GameObject.FindGameObjectWithTag("plataforma") == null)
            {
                Debug.Log("aad");
                Instantiate(prefab, new Vector3(Random.Range(LateralAnt.x - 2 * dist, LateralAnt.x), 46f, 0), Quaternion.identity);
            }
        }
        else
        {
            Destroy(GameObject.FindGameObjectWithTag("plataforma"));
        }
    }

}
