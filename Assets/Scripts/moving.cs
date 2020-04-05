using UnityEngine;
using System.Collections;

public class moving : MonoBehaviour
{
    //Variables
    float bLength = .4f;
    public float speedF = 6.0F;
    public int Phealth = 10;
    public int PTemphealth = 10, tempFuelLevel = 10;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float fuelLevel = 10f;
    public Vector3 moveDirection = Vector3.zero;
    public AstarPath aP;
    public Animator Robot;
    float timer = .15f;
    public FreeCam free;
    public ChangeCamera cC;
    public AudioSource JetPackSound;
    public bool JetOn = false, shid = false;
    public GameObject[] Healthbars = new GameObject[10];
    public GameObject[] Shieldbars = new GameObject[10];
    public GameObject[] Fuelbars = new GameObject[10];
    void Update()
    {
        if (JetOn && fuelLevel == 10)
        {
            for (int i = 0; i < 10; i++)
            {
                Fuelbars[i].SetActive(true);
            }
        }

        AstarPath.active.Scan();
        aP.astarData.gridGraph.center = new Vector3(transform.position.x, transform.position.y - 30, transform.position.z);

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

                speed = speedF * 1.5f;
            }
            else if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
            {

                speed = speedF;
            }

            moveDirection *= speed;
            //Jumping
            if (Input.GetButton("Jump"))
            {
                timer = .15f;
                if (Mathf.Abs(controller.velocity.x) > 2)
                {
                    Robot.Play("WalkJump2");
                }
                else
                {
                    Robot.Play("Jump3");
                }
                moveDirection.y = jumpSpeed;

            }
            if (JetOn)
                Fuel(-Time.deltaTime);
        }

        if (!controller.isGrounded)
        {
            if (Input.GetButton("Jump") && JetOn && fuelLevel > 0)
            {
                if (!JetPackSound.isPlaying)
                    JetPackSound.Play();
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                speed = speedF;
                moveDirection.y = jumpSpeed;
                Fuel(Time.deltaTime * 1.5f);
            }
            else
            {
                JetPackSound.Stop();
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

        Phealth -= (int)Damage;

        if (Phealth <= 0)
        {
            Phealth = 0;
            Robot.enabled = true;
            Robot.Play("RobotArmature|Robot_Death");
            Robot.GetComponentInParent<moving>().enabled = false;
            Robot.GetComponentInParent<CharacterController>().enabled = false;
            free.enabled = false;
            cC.dead = true;
        }
        if (Phealth > 10)
        {
            Phealth = 10;
        }
        if (Damage > 0)
        {
            for (int i = PTemphealth; i > Phealth; i--)
            {
                Healthbars[i - 1].SetActive(false);
            }
        }
        else
        {
            for (int i = PTemphealth; i < Phealth; i++)
            {
                Healthbars[i].SetActive(true);
            }
        }
        PTemphealth = Phealth;
    }
    public void Shield(float Damage)
    {

        Phealth += (int)Damage;
        print("WHERE ARR YOU STUCK YOU CDODE");
        print("THIS IS THE TEMP EHALTH" + PTemphealth);
        print("THIS IS THE  EHALTH" + Phealth);
        if (Phealth > 20)
        {
            Phealth = 20;
        }
        for (int i = PTemphealth; i < Phealth; i++)
        {
            print("WHERE ARR YOU STUCK");
            Shieldbars[i - 10].SetActive(true);
        }
        PTemphealth = Phealth;
    }
    public void Tramp(float jump)
    {
        CharacterController controller = GetComponent<CharacterController>();
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection.y = jump;
        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move

        Robot.SetFloat("Speed", Mathf.Abs(controller.velocity.x));

        controller.Move(moveDirection * Time.deltaTime);
    }
    public void Fuel(float fueld)
    {
        fuelLevel -= fueld;
        if (fuelLevel < 0)
        {
            fuelLevel = 0;
        }
        else if (fuelLevel > 10)
        {
            fuelLevel = 10;
        }
        if (fueld > 0)
        {
            for (int i = 9; i >= (int)fuelLevel; i--)
            {

                Fuelbars[i].SetActive(false);
            }
        }
        else
        {
            for (int i = tempFuelLevel; i < (int)fuelLevel; i++)
            {

                Fuelbars[i].SetActive(true);
            }
        }
        tempFuelLevel = (int)fuelLevel;
    }

}