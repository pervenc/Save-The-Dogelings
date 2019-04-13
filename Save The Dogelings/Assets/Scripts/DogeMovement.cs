

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]


public class DogeMovement : MonoBehaviour
{

    float maxPos = 2.6f;

    Rigidbody2D rb;
    Vector3 accel = Vector3.zero;

    public Animator anim;




    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(FirstJump());


        //var vel = Transform.rigidbody.velocity;      //to get a Vector3 representation of the velocity


    }



    void FixedUpdate()
    {


        accel = Input.acceleration;
        accel = Vector3.Lerp(accel, Input.acceleration, 0.015f);
        accel = accel * Time.deltaTime * 22;

        transform.Translate(accel.x, 0, 0);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -maxPos, maxPos), transform.position.y, transform.position.z);

        if (gameObject.GetComponent<Destructor>().gameIsOver == false)
        {

            if (accel.x < -0.01f)
            {

                GameObject.FindWithTag("Doge").GetComponent<SpriteRenderer>().flipX = true;
                GameObject.FindWithTag("Doge").GetComponent<SpriteRenderer>().flipX = true;


            }
            if (accel.x > 0.01f)
            {
                GameObject.FindWithTag("Doge").GetComponent<SpriteRenderer>().flipX = false;

            }

        }

        Vector3 veloc = rb.velocity;

        anim.SetFloat("speed", veloc.y);




        if (GetComponent<BonusItems>().isFlying == true)
        {
            anim.SetBool("flyFlower", true);

        }
        if (GetComponent<BonusItems>().isFlying == false)

        {
            anim.SetBool("flyFlower", false);

        }



        anim.SetBool("gameIsOver", gameObject.GetComponent<Destructor>().gameIsOver);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spikes"))
        {
            gameObject.GetComponent<Destructor>().gameIsOver = true;
            anim.SetBool("gameIsOver", true);

        }
    }



    IEnumerator FirstJump()
    {
        yield return new WaitForSeconds(0.1f);

        rb.gravityScale = 0.2f;

        rb.velocity = new Vector3(0, 20, 0);
        yield return new WaitForSeconds(0.15f);


        rb.gravityScale = 0.4f;
        yield return new WaitForSeconds(0.15f);
        rb.gravityScale = 0.7f;
        yield return new WaitForSeconds(0.15f);
        rb.gravityScale = 1f;
    }

}
