using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{




    public GameObject MoveCube;

    
    Vector3 startPos;
    float speed = 14.0f;
    float gravityMod = 2.0f;
    float absZ;

    bool isOnMoveCube = false;
    bool isOnStartCube = true;
    bool isOnCube = true;

    public GameObject movingCube;


    private int currentJump = 0;

    Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {


        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityMod;




    }

    // Update is called once per frame
    public void Update()
    {
       
        //horizontal
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * horizontalInput * speed);

        if (Input.GetKey(KeyCode.Space) && !isOnMoveCube && isOnStartCube && isOnCube)
        {
            playerRb.AddForce(Vector3.up * speed, ForceMode.Impulse);
            isOnCube = false;
        }

        if (Input.GetKey(KeyCode.Space) && isOnMoveCube && !isOnStartCube && isOnCube)
        {
            playerRb.AddForce(Vector3.up * speed, ForceMode.Impulse);
            isOnCube = false;
        }

        if (isOnMoveCube && isOnCube)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, movingCube.transform.position.z - absZ);
        }

        if (isOnStartCube && isOnCube)
        {
            transform.position = startPos;
        }

        //vertical
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * verticalInput * speed);




    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MoveCubeTag"))
        {
            isOnMoveCube = true;
            isOnStartCube = false;
            isOnCube = true;

            float playerZ = transform.position.z;
            float cubeZ = movingCube.transform.position.z;

            absZ = cubeZ - playerZ;
            transform.position = new Vector3(transform.position.x, transform.position.y, movingCube.transform.position.z - absZ);

        }

        if (collision.gameObject.CompareTag("StartCubeTag"))
        {
            isOnMoveCube = false;
            isOnStartCube = true;
            isOnCube = true;

            startPos = transform.position;
        }
    }
}

   
   




