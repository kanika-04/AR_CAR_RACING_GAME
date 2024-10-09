using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController2 : MonoBehaviour
{
   public Rigidbody theRB;
   public float forwardAccel= 8f,reverseAccel=8f,maxSpeed=50f, turnStrength=180;
   private float speedInput, turnInput;
   void start(){
		  theRB.transform.parent=null;

   }

   void Update (){
		  speedInput=0f;
		  if(Input.GetAxis("Vertical")>0){
				speedInput = Input.GetAxis("Vertical")*forwardAccel*1000f;
		  }
		  else  if(Input.GetAxis("Vertical")<0){
				speedInput = Input.GetAxis("Vertical")*reverseAccel*1000f;

		  }
		  turnInput=Input.GetAxis("Horizontal");
		  
		  transform.position=theRB.transform.position;
		  
   }
   private void FixedUpdate(){
		  if(Mathf.Abs(speedInput)>0){
				theRB.AddForce(transform.forward*speedInput);

		  }
   }
}
