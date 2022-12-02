using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //POUR COMPTEUR

public class DisplayCoin : MonoBehaviour
{
    public TMP_Text coinText; //POUR COMPTEUR

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = GameManager.instance.nbCoin.ToString();
    }
}
