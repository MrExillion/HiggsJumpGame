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
        if (GetComponent<PlayerCore>().freezePlayer)
        {
            return;
        }
        moveforce = 50f;
        
        //jumpforce = (jumpforce - Time.fixedDeltaTime * moveforce) * (1 - Mathf.Min(rb.velocity.y, 5f) / 5f);
        moveforce = (moveforce - Time.deltaTime * moveforce) * (1 - Mathf.Min(rb.velocity.magnitude,5f)/5f);       

        if(Mathf.Round(rb.velocity.y * 100) != 0) // Hang time Behavior
        {
            jumpforce = 0;
            rb.drag = 0.2f;
            moveforce = 0;
        }
        else //grounded behaviour
        {
            rb.drag = 3;
            jumpforce = 10 * 9.810f;
        }

        if (Input.GetKey(KeyCode.Space))
        {

            rb.AddForce(gameObject.transform.up * jumpforce);
        }


        if (Input.GetKey(KeyCode.W))
        {
            
            rb.AddForce(gameObject.transform.forward * moveforce);
        }
        if (Input.GetKey(KeyCode.S))
        {

            rb.AddForce(gameObject.transform.forward * moveforce/2 * -1);
        }
        if (Input.GetKey(KeyCode.D))
        {

            rb.AddForce(gameObject.transform.right * moveforce / 2);
        }
        if (Input.GetKey(KeyCode.A))
        {

            rb.AddForce(gameObject.transform.right * moveforce / 2 * -1);
        }




   
      if(Input.GetAxis("Mouse X") > 0)
        {
            gameObject.transform.Rotate(gameObject.transform.up, Input.GetAxis("Mouse X") * Time.fixedDeltaTime * 100);

        }
      else if(Input.GetAxis("Mouse X") < 0)
        {
            gameObject.transform.Rotate(gameObject.transform.up, Input.GetAxis("Mouse X") * Time.fixedDeltaTime * 100);

        }
        else
        {
            //do nothing
        }

       if (Input.GetAxis("Mouse Y") > 0 ) // && Camera.main.transform.rotation.eulerAngles.x < -90 )
       {
            Camera.main.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x + Input.GetAxis("Mouse Y") * -1 * Time.fixedDeltaTime * 100, Camera.main.transform.eulerAngles.y, Camera.main.transform.eulerAngles.z);

       }
       else if (Input.GetAxis("Mouse Y") < 0 )//&& Camera.main.transform.rotation.eulerAngles.x > 90)
       {
            Camera.main.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x + Input.GetAxis("Mouse Y") * -1 * Time.fixedDeltaTime * 100, Camera.main.transform.eulerAngles.y, Camera.main.transform.eulerAngles.z);

        }

    }




}
