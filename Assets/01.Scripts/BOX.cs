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

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.position.x < -14f){
            PoolManager.instance.ReturnObject(this);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(!(col.gameObject.CompareTag("GROUND") || col.gameObject.CompareTag("BOX")))
        {
            rigid.AddForce(Vector2.down * 200);
            
        }
    }
}
