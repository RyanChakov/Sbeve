using UnityEngine;
using System.Collections;

public class moving : MonoBehaviour
{
    //Variables
    public RectTransform hBar;
    float bLength = .4f;
    public float speedF = 6.0F;
    public float Phealth = 1f;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public AstarPath aP;
    public Animator Robot;
    float timer = .15f;
    public FreeCam free;
    public ChangeCamera cC;
    public bool JetOn=false;
    void Update()
    {
      
        AstarPath.active.Scan();
        aP.astarData.gridGraph.center = new Vector3(transform.position.x, transform.position.y-30, transform.position.z);

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
       
        if(!controller.isGrounded)
        {
           if(Input.GetButton("Jump") && JetOn)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                speed = speedF;
                moveDirection.y = jumpSpeed;
                print("Test");
            }
        }
        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move

        Robot.SetFloat("Speed", Mathf.Abs(controller.velocity.x));
       
        controller.Move(moveDirection * Time.deltaTime);
    }
   public void Health(float Damage)
    {
        Phealth -= Damage/10;
        bLength -= (Damage/100)*4;
        if (bLength <= 0)
        {
            bLength = 0;
            Robot.enabled = true;
            Robot.Play("RobotArmature|Robot_Death");
            Robot.GetComponentInParent<moving>().enabled = false;
            Robot.GetComponentInParent<CharacterController>().enabled = false;
            free.enabled = false;
            cC.dead = true;
        }


        hBar.localScale = new Vector3(bLength, .09f, 1);

    }
}