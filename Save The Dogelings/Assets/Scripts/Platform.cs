using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    public float jumpforce;
    float vel;






    void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = Other.collider.GetComponent<Rigidbody2D>();


            rb.AddForce(Vector3.up * jumpforce, ForceMode2D.Impulse);

                


            /*
            Vector2 velocity = rb.velocity;
                velocity.y = jumpforce;
                rb.velocity = velocity;
            */

        }



    }



   

}
