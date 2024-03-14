using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.UI;

public class PlayMovment : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask ground;


    Rigidbody rb;
    [SerializeField] float jumdForce = 5f;
    [SerializeField] float movementSpeed = 6f;

    [SerializeField] AudioSource jumpSound;
    // [SerializeField] private InputActionReference moveActionToUse;
    // Vector2 moveVector;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);


        //Vector3 moveDirection = new Vector3 (moveVector.x,0, moveVector.y);
        // moveDirection.Normalize();
        // transform.Translate(moveDirection * movementSpeed * Time.deltaTime);



        if (Input.GetButtonDown("Jump") && IsGround())
        {
            jump();
        }

        bool IsGround()
        {
            return Physics.CheckSphere(groundCheck.position, .3f, ground);

        }

    }



    public void jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumdForce, rb.velocity.z);
       
    }
}