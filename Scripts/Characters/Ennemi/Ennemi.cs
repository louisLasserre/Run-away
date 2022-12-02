using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : Character
{
    [SerializeField] private string direction;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

    }   
        // Update is called once per frame
    void Update()
    {
        if(direction != null)
        {
            Walk(direction);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            player.Killed();
        }

        if(collision.gameObject.tag == "DemiTourUp")
        {
            direction = "top";
        }
        if(collision.gameObject.tag == "DemiTourLeft")
        {
            direction = "left";
        }
        if(collision.gameObject.tag == "DemiTourRight")
        {
            direction = "right";
        }

        if (collision.gameObject.tag == "DemiTourDown")
        {
            direction = "down";
        }


    }
}
