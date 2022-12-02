using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Player : Character
{

    [SerializeField] private bool actionKeyOn;
    [SerializeField] private string actionKey;
    [SerializeField] private bool isRunning;

    [SerializeField] private List<string> collectiblesList;
    [SerializeField] private float runningSpeed;
    [SerializeField] private float walkingSpeed;


    [SerializeField] private Vector3 respawnPoint;
    [SerializeField] private int sceneNumber;
    [SerializeField] private GameManager GM;
    public Collider2D isTriggered;







    //--------constructor----------
    protected override void Start()
    {
        base.Start();

        this.runningSpeed = 50f;
        this.walkingSpeed = 30f;
        this.speed = this.walkingSpeed;

        this.collectiblesList = new List<string>();
        this.actionKeyOn = false;
        


    }

    //------unity native fonctions--------
    private void OnMovement(InputValue value)
    {
        
        Move(value.Get<Vector2>());
    }
    private void Update()
    {
        this.GM = FindObjectOfType<GameManager>();
        Sprint();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.actionKeyOn = true;
            TriggerPopUp(this.isTriggered);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            this.actionKeyOn = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Collectible"))
        {
            collectiblesList.Add(collision.GetComponent<Collectibles>().name);

            lasers finalgate = FindObjectOfType<lasers>();
            if (HasCollectibles(GM.ObjectRequiredToChangeLevel) && collision.gameObject.tag != "Coins")
            {
                finalgate.open();
            }
            else
            {
                finalgate.close();
            }
        }

    }


    //----seter-----
    public void setIstrigger(Collider2D collision)
    {
        this.isTriggered = collision;
    }


    //------object methods-messages--------
    public void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            this.speed = runningSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            this.speed = walkingSpeed;
        }
    }
    public void Killed()
    {
        Debug.Log("Killed");
        SceneManager.LoadScene(sceneNumber, LoadSceneMode.Single);
        
        //PlayerBehavior.spawn = ;
    }
    public void IsCraftable()
    {
        Debug.Log("Player.IsCraftable");
    }

    
    
    

    private void TriggerPopUp(Collider2D collision)
    {
        if (collision && collision.gameObject.CompareTag("Helper") && this.actionKeyOn)
        {

            Helper helper = collision.GetComponent<Helper>();

            helper.TriggerAction();
        }
    }
   
    public bool HasCollectibles(List<string> RequiredCollectibles)
    {
        foreach (string element in RequiredCollectibles)
        {
            if (!collectiblesList.Contains(element))
            {
                return false;
            }
        }

        return true;
    }

    
}
