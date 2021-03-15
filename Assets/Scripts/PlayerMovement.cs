using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;


    public float moveSpeed;
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float jumpHeight = 2f;

    public Animator anim;

    public float gravity = -19.62f;
    public float groundDistance = 0.4f;

    public float mouseSensitivity = 100f;

    public Transform groundCheck;

    public LayerMask groundMask;

    private bool isGrounded;

    private Vector3 velocity;

    public GameObject startPoint;
    public GameObject endPoint;
    public GameObject[] climbPath;

    public GameObject startPoint1;
    public GameObject middlePoint1;
    public GameObject endPoint1;

    public GameObject startPoint3;
    public GameObject endPoint3;

    public float climbSpeed = 2f;

    private bool isClimbing;
    private bool climbEnter;
    private bool climbExit;
    private bool climbEnter1;
    private bool climbMiddle1;
    private bool climbExit1;
    private bool climbEnter2;
    private bool climbExit2;

    private int current;


    private void Start()
    {
        anim = GetComponentInChildren<Animator>();

        isClimbing = false;
        climbEnter = false;
        climbExit = false;
        climbEnter1 = false;
        climbMiddle1 = false;
        climbExit1 = false;
        climbEnter2 = false;
        climbExit2 = false;

    }


    //Update is called once per frame
    void FixedUpdate()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float mouseInput = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        /*if(climbEnter == true && isClimbing == false && Input.GetKey(KeyCode.W))
        {
            isClimbing = true;
            transform.position = climbPath[0].transform.position;
            Debug.Log("Start Climbing");
        }

        if (climbEnter == true && isClimbing == true && Input.GetKeyDown(KeyCode.W))
        {
            isClimbing = false;
            transform.position = startPoint.transform.position;
            Debug.Log("Stop Climbing");
        }

        if (climbExit == true && isClimbing == true && Input.GetKeyDown(KeyCode.W))
        {
            isClimbing = false;
            transform.position = endPoint.transform.position;
            Debug.Log("Stop Climbing");
        }

        if (climbExit == true && isClimbing == false && Input.GetKeyDown(KeyCode.S))
        {
            isClimbing = true;
            transform.position = climbPath[climbPath.Length - 1].transform.position;
            Debug.Log("Start Climbing Down");
        }

        if (isClimbing == true)
        {

            if (transform.position != climbPath[current].transform.position)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    transform.position = Vector3.MoveTowards(transform.position, climbPath[current].transform.position, climbSpeed * Time.deltaTime);
                    Debug.Log("Climbing Up");
                }
                else
                {
                    transform.position = transform.position;
                    Debug.Log("Climbing Idle");
                }

                if (Input.GetKey(KeyCode.S))
                {
                    transform.position = Vector3.MoveTowards(transform.position, climbPath[current - 1].transform.position, climbSpeed * Time.deltaTime);
                    Debug.Log("Climbing Down");
                }
                else
                {
                    transform.position = transform.position;
                    Debug.Log("Climbing Idle");
                }
            }

            if (transform.position == climbPath[current].transform.position)
            {
                current = (current + 1) % climbPath.Length;
                Debug.Log("Climbing Changed");
            }

            if (transform.position == climbPath[current - 1].transform.position)
            {
                current = (current - 1) % climbPath.Length;
            }

        }*/

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = transform.right * x + transform.forward * z;


        if (Input.GetKey(KeyCode.LeftShift))
        {

            moveSpeed = runSpeed;

        }
        else
        {
            moveSpeed = walkSpeed;

        }


        controller.Move(move * moveSpeed * Time.deltaTime);

        transform.Rotate(Vector3.up * mouseInput);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(climbEnter == true && Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = endPoint.transform.position;
        }

        if(climbExit == true && Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = startPoint.transform.position;
        }

        if (climbMiddle1 == true && Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = startPoint1.transform.position;
        }

        if (climbExit1 == true && Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = middlePoint1.transform.position;
        }

        if (climbEnter1 == true && Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = endPoint1.transform.position;
        }

        if (climbEnter2 == true && Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = endPoint3.transform.position;
        }

        if (climbExit2 == true && Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = startPoint3.transform.position;
        }



        if (Input.GetKey(KeyCode.W) && moveSpeed == walkSpeed)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isWalkingBack", true);
        }
        else
        {
            anim.SetBool("isWalkingBack", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isWalkingLeft", true);
        }
        else
        {
            anim.SetBool("isWalkingLeft", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalkingRight", true);
        }
        else
        {
            anim.SetBool("isWalkingRight", false);
        }

        if (Input.GetKey(KeyCode.W) && moveSpeed == runSpeed)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.W) && isClimbing == true)
        {
            anim.SetBool("isClimbing", true);
        }
        else
        {
            anim.SetBool("isClimbing", false);
        }

        if (Input.GetKey(KeyCode.S) && isClimbing == true)
        {
            anim.SetBool("isClimbing", true);
        }
        else
        {
            anim.SetBool("isClimbing", false);
        }

        if (isClimbing == true)
        {
            anim.SetBool("isClimbingIdle", true);
        }
        else
        {
            anim.SetBool("isClimbingIdle", false);
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ClimbStart")
        {
            climbEnter = true;

            Debug.Log("Has Entered ClimbStart");
        }

        if (other.gameObject.tag == "ClimbEnd")
        {
            climbExit = true;
            Debug.Log("Has Entered ClimbEnd");
        }

        if (other.gameObject.tag == "ClimbStart1")
        {
            climbEnter1 = true;

            Debug.Log("Has Entered ClimbStart");
        }

        if (other.gameObject.tag == "ClimbMiddle1")
        {
            climbMiddle1 = true;

            Debug.Log("Has Entered ClimbMiddle1");
        }

        if (other.gameObject.tag == "ClimbEnd1")
        {
            climbExit1 = true;
            Debug.Log("Has Entered ClimbEnd1");

        }

        if (other.gameObject.tag == "ClimbStart2")
        {
            climbEnter2 = true;

            Debug.Log("Has Entered ClimbStart2");
        }

        if (other.gameObject.tag == "ClimbEnd2")
        {
            climbExit2 = true;
            Debug.Log("Has Entered ClimbEnd2");

        }

    }

    private void OnTriggerExit(Collider other)
    {

            if (other.gameObject.tag == "ClimbStart")
            {
                climbEnter = false;
                Debug.Log("Has Exited ClimbStart");
            }

            if (other.gameObject.tag == "ClimbEnd")
            {
                climbExit = false;
                Debug.Log("Has Exited ClimbEnd");
            }

            if (other.gameObject.tag == "ClimbStart1")
            {
                climbEnter1 = false;
                Debug.Log("Has Exited ClimbStart1");
            }

            if (other.gameObject.tag == "ClimbMiddle1")
            {
                climbMiddle1 = false;
                Debug.Log("Has Exited ClimbMiddle1");
            }


            if (other.gameObject.tag == "ClimbEnd1")
                {
                    climbExit1 = false;
                    Debug.Log("Has Exited ClimbEnd");
                }

            if (other.gameObject.tag == "ClimbStart2")
            {
                climbEnter2 = false;

                Debug.Log("Has Entered ClimbStart2");
            }

            if (other.gameObject.tag == "ClimbEnd2")
            {
                climbExit2 = false;
                Debug.Log("Has Entered ClimbEnd2");

            }

    }
}
