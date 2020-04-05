using UnityEngine;

public class FreeCam : MonoBehaviour
{
    public GameObject player;
    public GameObject head;
    public float movementSpeed = 10f;
    public Skeleton SKL;
    public float freeLookSensitivity = 3f;
    public Animator Robot;
    public bool looking = true, laser = false;
    public AudioSource attackSkelSound, attackAir;
    int layerMask = 1 << 14;
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            if (!laser)
            {
                Robot.Play("RobotArmature|Robot_Punch");

                //Spammable
                /*
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), 4, layerMask))
                {
                    attack();
                    attackSkelSound.Play();
                }
                */
                // Not spammable

                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), 4, layerMask) && !attackSkelSound.isPlaying)
                {
                    attack();
                    attackSkelSound.Play();
                }
                else if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), 4, layerMask))
                {
                    attackAir.Play();
                }
            }

        }


        var movementSpeed = this.movementSpeed;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.position = player.transform.position + (-player.transform.right * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.position = player.transform.position + (player.transform.right * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            player.transform.position = player.transform.position + (player.transform.forward * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            player.transform.position = player.transform.position + (-player.transform.forward * movementSpeed * Time.deltaTime);
        }

        if (looking)
        {

            float newRotationX = player.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * freeLookSensitivity;
            float newRotationY = this.transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * freeLookSensitivity;
            print("THIS IS THE ROTATION" + newRotationX);
            player.transform.localEulerAngles = new Vector3(0, newRotationX, 0f);
            // -90 to 90

            if (newRotationY > 90 && newRotationY < 200)
            {
                newRotationY = 90;
            }
            this.transform.localEulerAngles = new Vector3(newRotationY, 0, 0f);

        }



        // StartLooking();
    }

    void OnDisable()
    {
        //  StopLooking();
    }
    /*
   
    public void StartLooking()
    {
        
        looking = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

   
    public void StopLooking()
    {
        looking = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    */
    void attack()
    {

        if (SKL.SHelath != 0)
        {
            SKL.SHelath -= 1f;
        }

    }
}
