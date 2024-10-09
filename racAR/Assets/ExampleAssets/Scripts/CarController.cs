using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // Start is called before the first frame update
    private float moveInput;
    private bool isCarGrounded; 
    private float turnInput;
    public LayerMask groundLayer; 
    public float turnSpeed;
    public float airDrag;
    public float groundDrag;

    public float fwdSpeed;

    public Rigidbody sphereRB;

    public float revSpeed;


    void Start()
    {
        sphereRB.transform.parent = null;
        
    }

    // Update is called once per frame
    void Update()
    { transform.position = sphereRB.transform.position;
         moveInput = Input.GetAxisRaw("Vertical");
         turnInput = Input.GetAxisRaw("Horizontal");
         moveInput *= moveInput>0 ? fwdSpeed : revSpeed;

        
         float newRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
         transform.Rotate(0,newRotation,0);

         RaycastHit hit;
         isCarGrounded = Physics.Raycast(transform.position,-transform.up, out hit, 1f, groundLayer);

         transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;

         if(isCarGrounded)
         {
            sphereRB.drag=groundDrag;
         }
         else
         {
            sphereRB.drag=airDrag;
         }
        
    }

     private void FixedUpdate()
     {   if(isCarGrounded)
     {
        sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
     }

    else
     {
      sphereRB.AddForce(transform.up * -30f);
        
     }
     }
}