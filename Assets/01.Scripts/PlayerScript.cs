using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject map;
    Rigidbody2D rigid;
    float jumpPower;
    float gravityPower;
    bool isGround;
    public bool isBox;
    [SerializeField]
    private Transform ground;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private LayerMask whatIsBox;
    public float boxDistance;
    
    private void Init(){
        rigid = GetComponent<Rigidbody2D>();
        GroundCheck();
        BoxCheck();
        jumpPower = 5f;
        gravityPower = 7f;
    }
    /*
    public void Jump(){
        if(isGround){
            
            rigid.velocity = Vector2.zero;
            rigid.AddForce(Vector2.up * jumpPower * 50);
            isGround = false;
            Gravity();
        }
        
    }
    */
    private void Gravity(){
        rigid.AddForce(Vector2.down * gravityPower * 20);
        
    }
    private void GroundCheck()
    {
        if (rigid.velocity.y < 0)
        {
            isGround = Physics2D.OverlapCircle(ground.position, 0.3f, whatIsGround); // 반지름이 0.2인 원에 ground가 닿으면 isGround를 true로 바꿔주는것
            
        }
    }
    private void BoxCheck(){
        if(rigid.velocity.y < 0){
            isBox = Physics2D.OverlapCircle(ground.position,0.3f,whatIsBox);
            /*
            if(Physics2D.Raycast(transform.position,Vector2.down, 10f,out hit)){
                
            }
            */
        }
    }
    private void CreateBox(){
        if (Input.GetKeyDown(KeyCode.S) )//&& isGround)
        {
            if(!isBox){

                var boxObj = PoolManager.instance.GetObject();
                boxObj.transform.position = new Vector3(this.transform.position.x + (this.gameObject.transform.localScale.x + 0.5f), this.transform.position.y + 0.5f, this.transform.position.z);
                boxObj.transform.SetParent(map.transform);
            }
            else{
                
                var boxObj = PoolManager.instance.GetObject();
                boxObj.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, this.transform.position.z);
                this.gameObject.transform.position = new Vector3(
                    this.transform.position.x,this.transform.position.y + 1f,this.transform.position.z
                );
                boxObj.transform.SetParent(map.transform);
            }
        }
    }
    
    private void Awake(){
        Init();
    }
    private void Update(){
        GroundCheck();
        BoxCheck();
        //Jump();
        CreateBox();
    }
}
