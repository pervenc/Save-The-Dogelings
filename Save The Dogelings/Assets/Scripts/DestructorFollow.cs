using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructorFollow : MonoBehaviour
{
    public Transform targetToFollow;
    public Vector3 offset;
    private int firstOffset;
    void Start()
    {
        firstOffset = -3;
        StartCoroutine(StartFollowing());

    }


    void Update()
    {
         if ((targetToFollow.position.y - transform.position.y)>0.2f)
        {
            transform.position = new Vector3(transform.position.x, targetToFollow.position.y + firstOffset, transform.position.z) + offset;

        }

    }


    IEnumerator StartFollowing()
    {
       
        yield return new WaitForSeconds(1.5f);
        firstOffset = 0;


    }
}
    