using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOX : MonoBehaviour
{
    Rigidbody2D rigid;
    public static bool isb = true;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() 
    {
        StartCoroutine(Return());
    }
    // Update is called once per frame
    void Update()
    {
            /*
            if(this.gameObject.transform.position.x < -20f){
                PoolManager.instance.ReturnObject(this);
                Debug.Log("Return");
            }
            */
        
    }
    IEnumerator Return(){
        yield return new WaitForSeconds(1f);
        PoolManager.instance.ReturnObject(this);
        Debug.Log("Return_" + this.gameObject.name);
        
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(!(col.gameObject.CompareTag("GROUND") || col.gameObject.CompareTag("BOX")))
        {
            rigid.AddForce(Vector2.down * 500);
            
        }
    }
    
}
