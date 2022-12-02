using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Helper : Character
{

    [SerializeField] private List<GameObject> dialogueList;
    [SerializeField] private int currentDialogueIndex;



    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameManager GM;


    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        GM = FindObjectOfType<GameManager>();
        
        
    }

   

    public void nextDialogue()
    {
        if(this.currentDialogueIndex < this.dialogueList.Count)
        {
            this.speakDialogue(this.currentDialogueIndex + 1);
        }
    }
    public void speakDialogue(int index = 0)
    {

        if(this.GM.activePopUp != this.dialogueList[index])
        {

            if(index < this.dialogueList.Count)
            {

                this.GM.showPopUp(this.dialogueList[index]);
                this.currentDialogueIndex += 1;
            }
        }
    }

    public void TriggerAction()
    {
        if(this.currentDialogueIndex > this.dialogueList.Count -1)
        {
            this.currentDialogueIndex = 0;
        }

        
         this.speakDialogue(this.currentDialogueIndex);

        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Player>().setIstrigger(gameObject.GetComponent<Collider2D>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Player>().setIstrigger(null);

        }
    }
}
