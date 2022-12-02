using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private int RestartSceneNumber;
    [SerializeField] private int MenuSceneNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame ()
    {
        SceneManager.LoadScene(RestartSceneNumber, LoadSceneMode.Single);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(MenuSceneNumber, LoadSceneMode.Single);
    }
}
