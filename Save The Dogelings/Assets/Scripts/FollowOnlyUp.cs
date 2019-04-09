using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowOnlyUp : MonoBehaviour
{
    public Transform targetToFollow;
    public Vector3 offset;




    void FixedUpdate()
    {
       
            transform.position = new Vector3(transform.position.x, targetToFollow.position.y, transform.position.z)+offset ;

        

    }
}
