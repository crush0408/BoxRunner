 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public Animator animator;
    public GameObject map;
    Rigidbody2D rigid;
    StageManager stageManager;
    float jumpPower;
    float gravityPower;
    public bool isGround;
    public bool isBox;
    public bool isJump;
    [SerializeField]
    private Transform ground;
    [SerializeField]
    private Transform jump;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private LayerMask whatIsBox;
    [SerializeField]
    private LayerMask whatIsJump;
    public float boxDistance;

    public float deathY;

    public Text boxText;
    public int canBox;
    private void Init()
    {
        animator = GetComponent<Animator>();
        stageManager = FindObjectOfType<StageManager>();
        rigid = GetComponent<Rigidbody2D>();
        BoxUpdate();
        GroundCheck();
        BoxCheck();
        JumpCheck();
        jumpPower = 10f;
        gravityPower = 7f;
    }
    private void Awake()
    {
        Init();
    }
    public void Jump()
    {
        rigid.velocity = Vector2.zero;
        rigid.AddForce(Vector2.up * jumpPower * 150f);
        isGround = false;
    }
    private void GroundCheck()
    {
        if (rigid.velocity.y < 0)
        {
            isGround = Physics2D.OverlapCircle(ground.position, 0.3f, whatIsGround); 
            // 반지름이 0.2인 원에 ground가 닿으면 isGround를 true로 바꿔주는것
        }
    }
    private void BoxCheck()
    {
        if (rigid.velocity.y < 0)
        {
            isBox = Physics2D.OverlapCircle(ground.position, 0.3f, whatIsBox);
        }
    }
    private void JumpCheck()
    {
        isJump = Physics2D.Raycast(jump.position, Vector2.up, 1.9f, whatIsJump);
    }
    public void CreateBox()
    {
        if (DataManager.instance.isPlaying && canBox > 0 && !isJump)
        {
            if (!isBox)
            {
                PoolableMono boxObj;
                if(DataManager.instance.boxSkinIndex == 0)
                {

                    boxObj = PoolManager.Instance.Pop("Box");
                }
                else
                {
                    boxObj = PoolManager.Instance.Pop("BOX_Christmas");
                }
                boxObj.transform.position = new Vector3(this.transform.position.x + (this.gameObject.transform.localScale.x + 0.5f), this.transform.position.y + 0.5f, this.transform.position.z);

                boxObj.transform.SetParent(map.transform);
                canBox--;
                BoxUpdate();
                MGSound.instance.playEff("Box");
            }
            else
            {
                PoolableMono boxObj;
                if (DataManager.instance.boxSkinIndex == 0)
                {

                    boxObj = PoolManager.Instance.Pop("Box");
                }
                else
                {
                    boxObj = PoolManager.Instance.Pop("BOX_Christmas");
                }
                boxObj.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, this.transform.position.z);
                this.gameObject.transform.position = new Vector3(
                    this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z
                );

                boxObj.transform.SetParent(map.transform);
                canBox--;
                BoxUpdate();
                MGSound.instance.playEff("Box");
            }
        }
    }
    public void BoxUpdate()
    {
        boxText.text = $"{canBox}";
    }
    private void Drop()
    {
        if(this.gameObject.transform.position.y < deathY)
        {
            Dead();
        }
    }
    public void Dead()
    {
        stageManager.GameResult(false);
        SceneManager.LoadScene("ClearOver");
    }
    private void Update()
    {
        Drop();
        GroundCheck();
        BoxCheck();
        BoxUpdate();
        JumpCheck();
    }
    private void OnCollisionEnter2D(Collision2D col){
        
        if(col.gameObject.CompareTag("SPIKE")){
            DataManager.instance.isPlaying = false;
            animator.SetTrigger("isHit");
            //플레이어 애니메이션 재생
        }
    }
    private void OnTriggerEnter2D(Collider2D col){
        
        if(col.gameObject.CompareTag("BOX_ADD")){
            MGSound.instance.playEff("AddBox");
            canBox += 3;
            BoxUpdate();
            col.gameObject.SetActive(false);
        }
        
    }
}
