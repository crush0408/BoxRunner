using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public int coin;
    public Text coinText;
    void Start()
    {
        coin = 0;
        coinText.text = $"coin : {coin}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CoinUpdate(){
        coin++;
        coinText.text = $"coin : {coin}";
    }
}
