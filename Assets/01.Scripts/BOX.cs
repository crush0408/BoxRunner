using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOX : MonoBehaviour
{
    public Animator animator;
    Rigidbody2D rigid;
    
    public static bool isb = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() 
    {
        StartCoroutine(Return());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Return(){
        yield return new WaitForSeconds(1f);
        PoolManager.instance.ReturnObject(this);
        Debug.Log("Return_" + this.gameObject.name);
        
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("SPIKE")){
            //박스 애니메이션 실행
            animator.SetTrigger("IsDestroy");
            Debug.Log("Return_" + this.gameObject.name);
        }
        else if(!(col.gameObject.CompareTag("GROUND") || col.gameObject.CompareTag("BOX")))// && !col.gameObject.CompareTag("SPIKE"))
        {
            rigid.AddForce(Vector2.down * 500);
            Debug.Log("떨어짐");   
        }
    }
    public void D(){
        PoolManager.instance.ReturnObject(this);
    }
    
}
