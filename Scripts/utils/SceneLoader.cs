using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int sceneNumber;
    [SerializeField] private GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player Player = collision.GetComponent<Player>();


            if(Player.HasCollectibles(GM.ObjectRequiredToChangeLevel))
            {
                GameManager gm = FindObjectOfType<GameManager>();
                gm.levelGate = null;

                SceneManager.LoadScene(sceneNumber, LoadSceneMode.Single);
                Vector3 spawn = new Vector3(0, 0, 0);
                collision.gameObject.GetComponent<Transform>().position = spawn;



                


            }

        }
    }

  
}