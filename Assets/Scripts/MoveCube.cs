using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    float speed = 1.0f;
    float zLimit = 27.5f;
    bool isForward = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      

        if (transform.position.z < 25.0f && isForward == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else if (transform.position.z > 1 && isForward == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -speed);
        }
        else
        {
            isForward = !isForward;
        }
    }
}
