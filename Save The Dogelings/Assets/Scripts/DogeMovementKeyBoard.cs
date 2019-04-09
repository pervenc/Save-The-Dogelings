using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogeMovementKeyBoard : MonoBehaviour
{



    float maxPos = 3.14f;
    float movementRotationChange;

    Rigidbody2D rb;
    float moveSpeedForKeyBoard = 500f;
    float movementForKeyBoard;



    void Start()
    {

        rb = GetComponent<Rigidbody2D>();




    }

    void FixedUpdate()
    {

        Vector2 velocityForKeyBoard = rb.velocity;
        velocityForKeyBoard.x = movementForKeyBoard;
        if (GameObject.FindWithTag("Doge").GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Static)

        {
            rb.velocity = velocityForKeyBoard;

        }

        movementForKeyBoard = Input.GetAxis("Horizontal") * moveSpeedForKeyBoard * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -maxPos, maxPos), transform.position.y, transform.position.z);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -maxPos, maxPos), transform.position.y, transform.position.z);








        movementRotationChange = Input.GetAxisRaw("Horizontal") * 10;

        if (GetComponent<Destructor>().gameIsOver == false)
        {
            if (movementRotationChange < -1f)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            if (movementRotationChange > 1f)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

        }

        // Debug.Log(movementRotationChange);


    }
}
