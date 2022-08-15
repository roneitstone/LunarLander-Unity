using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Type : MonoBehaviour
{
    public GameObject navebase;
    public GameObject naveAngular;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("nave") == 0)
        {
            navebase.SetActive(true);
        }
        else
        {
            naveAngular.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
