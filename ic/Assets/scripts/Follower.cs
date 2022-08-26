using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(obj.transform.position.x > 0f)
        {
            transform.position = new Vector3(obj.transform.position.x, transform.position.y, transform.position.z);

        }
    }
}
