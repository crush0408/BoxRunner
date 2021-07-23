using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCheck : MonoBehaviour
{
    public GameObject bg;
    public PlayerScript player;
    public float jump;
    public float width;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col){
        
        if (col.gameObject.CompareTag("BOX") && !player.isBox)
        {
            player.transform.position = new Vector3(col.gameObject.transform.position.x + width,
            col.gameObject.transform.position.y + jump,col.transform.position.z);
            
        }
    }
}
