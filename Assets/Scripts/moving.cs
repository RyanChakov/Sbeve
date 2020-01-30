using UnityEngine;
using System.Collections;

public class moving : MonoBehaviour
{
    //Variables
    public float speedF = 6.0F;
    public float Phealth = 1f;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public AstarPath aP;
    public Animator Robot;
    float timer = .15f;
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
            {
                timer = .15f;
            if(Mathf.Abs(controller.velocity.x) >2)
                {
                    Robot.Play("WalkJump2");
                }
                else
                {
                    Robot.Play("Jump3");
                }
                moveDirection.y = jumpSpeed;

            }

        }
        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move

        Robot.SetFloat("Speed", Mathf.Abs(controller.velocity.x));
       
        controller.Move(moveDirection * Time.deltaTime);
    }
}