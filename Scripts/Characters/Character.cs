using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character: MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected string characterName = "name";

    protected Vector2 movement;
    private Rigidbody2D rb2d;
    private Animator animator;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        //movement
        rb2d.AddForce(movement * speed);
    }

    //------constructor------
    protected virtual void Start()
    {
        
    }


    //-----------get and set of the attributes-----------
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }



    //-----------methodes-messages-----------

    public void Move(Vector2 movingVector)
    {
        movement = movingVector;

        if(movement.x != 0 || movement.y != 0)
        {

            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);

            animator.SetBool("isWalking", true);
        }else {
            animator.SetBool("isWalking", false);

        }

    }
    public void Walk(string Direction)
    {
        float x = 0f;
        float y = 0f;

        switch (Direction)
        {
            case "right":
                x = 1f;
                y = 0f;
                break;

            case "down":
                x = 0f;
                y = -1f;
                break;

            case "left":
                x = -1f;
                y = 0f;
                break;

            case "top":
                x = 0f;
                y = 1f;
                break;


            default:
                Debug.LogError("Direction for walk() must be either right, down, left or top");
                break;
        }
        Move(new Vector2(x, y));

    }

    

    public void speak(string msg)
    {
        Debug.Log("Character.Speak");

    }
}
