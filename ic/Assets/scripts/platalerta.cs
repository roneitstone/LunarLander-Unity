using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platalerta : MonoBehaviour
{
    public bool pronto = false;
    float size;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(4, 0, true);
        size = Screen.width;

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chao"))
        {

            pronto = true;
            Physics2D.IgnoreLayerCollision(4, 0, false);
        }
    }
    void OnBecameInvisible()
    {
        Physics2D.IgnoreLayerCollision(4, 0, false);
        Destroy(gameObject);

    }
}
