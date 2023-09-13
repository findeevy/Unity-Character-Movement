using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unityCharacterMovement : MonoBehaviour
{
    public List<string> movements = new List<string> { };
    private float speed;
    public float speedMulti;
    public float gravity;
    public int stepAmount;
    public int step = 0;
    public float rotateX;
    public float rotateY;
    public float rotateZ;
    public float placeX;
    public float placeY;
    public float placeZ;
    public string stepDetails;
    public float stepLong;
    public CharacterController controller;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        stepAmount = movements.Count;
        stepDetails=movements[step];
        stepLong = int.Parse(stepDetails.Substring(4,stepDetails.Length-4));
        placeX = controller.transform.position.x;
        placeY = controller.transform.position.y;
        placeZ = controller.transform.position.z;
        rotateX = controller.transform.rotation.x;
        rotateY = controller.transform.rotation.y;
        rotateZ = controller.transform.rotation.z;
        

    }
    // Update is called once per frame
    void Update()
    {   
        speed=speed*Time.deltaTime;
        if(step<stepAmount){
        if(stepDetails.Substring(1,3) == "for"){
        velocity= new Vector3(0, gravity * Time.deltaTime, speedMulti*speed);
        controller.Move(velocity);
        stepLong-=Time.deltaTime*speedMulti;
        if(stepLong < 0){
        stepReset();
        }
        }	
	//Move Left
        else if(stepDetails.Substring(1,3) == "bac"){
        	velocity= new Vector3(0, gravity * Time.deltaTime, -speed*speedMulti);
        	controller.Move(velocity);
        	stepLong-=Time.deltaTime*speedMulti;
        	if(stepLong < 0){
        		stepReset();
        	}
        }
	//Move Left
        else if(stepDetails.Substring(1,3) == "lft"){
        	velocity= new Vector3(-speed*speedMulti, gravity * Time.deltaTime, 0);
        	controller.Move(velocity);
        	stepLong-=Time.deltaTime*speedMulti;
        	if(stepLong < 0){
        		stepReset();
        	}
        }
	//Move Right
        else if(stepDetails.Substring(1,3) == "rit"){
        	velocity= new Vector3(speed*speedMulti, gravity * Time.deltaTime, 0);
        	controller.Move(velocity);
        	stepLong-=Time.deltaTime*speedMulti;
        	if(stepLong < 0){
        		stepReset();
        	}
        }
	//Left Turn
        else if(stepDetails.Substring(1,3) == "LTR"){
        	transform.Rotate(Vector3.up * -45f * Time.deltaTime);
        	stepLong -= 45f*Time.deltaTime;
        	if(stepLong < 0){
        		stepReset();
        	}
        }
	//Right Turn
        else if(stepDetails.Substring(1,3) == "RTR"){
        	transform.Rotate(Vector3.up * 45f * Time.deltaTime);
        	stepLong -= 45f*Time.deltaTime;
        	if(stepLong < 0){
        		stepReset();
        	}
        }
        }
        else{
        	controller.enabled = false;
        	controller.transform.position= new Vector3(placeX,placeY,placeZ);
        	controller.transform.rotation = Quaternion.Euler(rotateX, rotateY, rotateZ);
        	controller.enabled = true;
        	step=0;
        	stepDetails=movements[step];
        	stepLong = int.Parse(stepDetails.Substring(4,stepDetails.Length-4));
        }

    }

    void stepReset()
    {   
        step += 1;
        stepDetails=movements[step];
        stepLong = int.Parse(stepDetails.Substring(4,stepDetails.Length-4));
    }
}
