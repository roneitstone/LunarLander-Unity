using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platafromapi : MonoBehaviour
{
    public Rigidbody2D rb;
    private float antigo = -499f;
    private float atual;
    bool ativado = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ativado == false)
        {
            atual = Random.Range(-188.0f, 186.0f);
            if (atual != antigo)
            {
                transform.position = new Vector2(atual, 86f);
                antigo = atual;
                ativado = true;
            }
        }
        else
        {
            rb.velocity = Vector2.down * 30f;
        }
    }
    public void reset()
    {
        ativado = false;
    }
}
