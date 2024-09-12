using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    private float moveforce = 250.0f;
    private float jumpforce = 98.10f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        moveforce = 50f;
        moveforce = (moveforce - Time.fixedDeltaTime * moveforce) * (1 - Mathf.Min(rb.velocity.magnitude,5f)/5f);
        



        //Debug.Log(rb.velocity.y);

        //if (rb.velocity.magnitude > 5f)
        //{
            
        //    if (rb.velocity.magnitude > 0f)
        //    {
        //        moveforce = 1 - (moveforce / rb.GetAccumulatedForce().magnitude);
        //    }
        //    else
        //    {
        //        moveforce = 0;
        //    }
        //}

        if(rb.velocity.y != 0)
        {
            jumpforce = 0;
            rb.drag = 0.2f;
            moveforce = 0;
        }
        else
        {
            rb.drag = 3;
            jumpforce = 10*9.810f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            
            rb.AddForce(gameObject.transform.forward * moveforce);
        }
        if (Input.GetKey(KeyCode.S))
        {

            rb.AddForce(gameObject.transform.forward * moveforce/2 * -1);
        }


        if (Input.GetKey(KeyCode.Space))
        {

            rb.AddForce(gameObject.transform.up * jumpforce);
        }
   
      if(Input.GetAxis("Mouse X") > 0)
        {
            gameObject.transform.Rotate(gameObject.transform.up, Input.GetAxis("Mouse X") * Time.fixedDeltaTime * 100);

        }
      else if(Input.GetAxis("Mouse X") < 0)
        {
            gameObject.transform.Rotate(gameObject.transform.up, Input.GetAxis("Mouse X") * Time.fixedDeltaTime * 100);

        }


    }




}
