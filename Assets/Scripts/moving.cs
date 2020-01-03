using UnityEngine;
using System.Collections;

public class moving : MonoBehaviour
{
    //Variables
    public float speedF = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public AstarPath aP;
    
    void Update()
    {
        AstarPath.active.Scan();
        aP.astarData.gridGraph.center = new Vector3(transform.position.x, transform.position.y-80, transform.position.z);

        float speed = speedF;
        CharacterController controller = GetComponent<CharacterController>();
        // is the controller on the ground?
        if (controller.isGrounded)
        {
            
            //Feed moveDirection with input.
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            //Multiply it by speed.
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
               
                speed =speedF*1.5f;
            }
            else if(!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
            {
                
                speed = speedF;
            }
            
            moveDirection *= speed;
            //Jumping
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move

       
        controller.Move(moveDirection * Time.deltaTime);
    }
}