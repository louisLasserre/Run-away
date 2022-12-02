using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasers : MonoBehaviour
{

    [SerializeField] GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void open()
    {
        GM = FindObjectOfType<GameManager>();
        gameObject.SetActive(false);
    }
    public void close()
    {
        GM = FindObjectOfType<GameManager>();
        gameObject.SetActive(true);
    }
}
