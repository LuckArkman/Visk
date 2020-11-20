using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour
{
    float Speed = 4.5f;
    [SerializeField] private float transition = 1f;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject gameObject;
    [SerializeField] private bool walk;
    [SerializeField] private bool Jump;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private bool arma;
    [SerializeField] private bool input;
    float speed;
    bool turnA, turnB;

    void Start()
    {
        turnA = true;
        turnB = false;
        input = true;
        arma = false;
        walk = false;
        Jump = false;
        rigidbody = GetComponent<Rigidbody>();
    }

    
    void LateUpdate()
    {        
        if (input == true)
        {
            Movement();
            Direction();
            walking();
            Jumping();
            Weapon();
            Dash();
        }
        else
        {
            return;
        }
        
        if (arma != false)
        {
            gameObjects[0].SetActive(true);
            gameObjects[1].SetActive(true);

        }
        else
        {
            gameObjects[0].SetActive(false);
            gameObjects[1].SetActive(false);
        }      

    }
    //Character movement 
    void Movement()
    {
        switch(walk)
        {
            case false:
                {
                    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                    {
                        animator.SetBool("Walk", false);
                        animator.SetBool("Idle", false);
                        animator.SetBool("Run", true);
                        transform.Translate(+0.04f, 0f, 0f, Space.World);
                    }
                    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                    {
                        animator.SetBool("Walk", false);
                        animator.SetBool("Idle", false);
                        animator.SetBool("Run", true);
                        transform.Translate(-0.04f, 0f, 0f, Space.World);
                    }
                    if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
                    {

                        animator.SetBool("Idle", true);
                        animator.SetBool("Walk", false);
                        animator.SetBool("Run", false);                        
                    }
                    if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
                    {
                        animator.SetBool("Idle", true);
                        animator.SetBool("Walk", false);
                        animator.SetBool("Run", false);
                    }
                    break;
                }
            case true:
                {
                    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                    {
                        animator.SetBool("Walk", true);
                        animator.SetBool("Idle", false);
                        animator.SetBool("Run", false);
                        transform.Translate(+0.01f, 0f, 0f, Space.World);
                    }
                    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                    {
                        animator.SetBool("Walk", true);
                        animator.SetBool("Idle", false);
                        animator.SetBool("Run", false);
                        transform.Translate(-0.01f, 0f, 0f, Space.World);
                    }
                    if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
                    {

                        animator.SetBool("Idle", true);
                        animator.SetBool("Walk", false);
                        animator.SetBool("Run", false);
                    }
                    if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
                    {
                        animator.SetBool("Idle", true);
                        animator.SetBool("Walk", false);
                        animator.SetBool("Run", false);
                    }
                    break;
                }
        }
        
        
    }
    //character Dash
    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            animator.SetBool("Dash", true);
        }
        else
        {
            animator.SetBool("Dash", false);

        }
    }

    //Character Walking
    void walking()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (walk != false)
            {
                walk = false;
            }
            else
            {
                walk = true;
            }
        }
    }
    //Valida Character Jumping
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Jump = true;
        }
        else
        {
            Jump = false;
        }
    }
    //Character Jumping
    void Jumping()
    {
        if (Jump == true && Input.GetKeyDown(KeyCode.K))
        {
            rigidbody.AddForce(new Vector3(0, 8f, 0), ForceMode.Impulse);
            Jump = false;
        }
    }
    //Hide & Show Weapon
    void Weapon()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (arma != false)
            {
                arma = false;
            }
            else
            {
                arma = true;
            }
        }
    }
    //Input Not Working
    void NotInput()
    {
        input = false;
        print("not Input");
        animator.SetBool("Idle", false);
        animator.SetBool("Walk", false);
        animator.SetBool("Run", false);
    }
    //Input Working
    void YInput()
    {
        input = true;
        print("input");
        animator.Play("Idle");


    }
    //Character Rotation
    void Direction()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (turnB != false)
            {
                animator.Play("Turn_D");
            }
            else
            {
                return;
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (turnA != false)
            {
                animator.Play("Turn_A");
            }
            else
            {
                return;
            }
        }        
    }

    void TurnA()
    {
        transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        turnB = true;
        turnA = false;

    }
    void TurnD()
    {
        transform.rotation = Quaternion.Euler(0f, 90f, 0f);       
        turnB = false;
        turnA = true;
    }
}
