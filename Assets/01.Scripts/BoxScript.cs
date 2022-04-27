using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : PoolableMono
{
    public Animator animator;
    Rigidbody2D rigid;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() 
    {
        StartCoroutine(Return());
    }
    void Update()
    {
        
    }
    IEnumerator Return(){
        yield return new WaitForSeconds(1f);
        animator.SetTrigger("IsDestroy");
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("SPIKE"))
        {
            animator.SetTrigger("IsDestroy");
        }
        else if(!(col.gameObject.CompareTag("GROUND") || col.gameObject.CompareTag("BOX")))
        {
            rigid.AddForce(Vector2.down * 500);
            Debug.Log("떨어짐");   
        }
    }

    public void ReturnBoxAnimFunc()
    {
        PoolManager.Instance.Push(this);
    }

    public override void Reset()
    {
        // Do Nothing
    }
}
