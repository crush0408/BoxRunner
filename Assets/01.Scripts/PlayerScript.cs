using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public Animator animator;
    public AudioClip BoxCreat;
    public GameObject map;
    Rigidbody2D rigid;
    StageManager stageManager;
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

    AudioSource audioSource;

    public int canBox;
    private void Init()
    {
        animator = GetComponent<Animator>();
        stageManager = FindObjectOfType<StageManager>();
        rigid = GetComponent<Rigidbody2D>();
        GroundCheck();
        BoxCheck();
        jumpPower = 10f;
        gravityPower = 7f;
    }

    public void AudioPlay()
    {
        audioSource.clip = BoxCreat;
        audioSource.Play();
    }
    
    public void Jump(){
        
        if(isGround){
            rigid.velocity = Vector2.zero;
            rigid.AddForce(Vector2.up * jumpPower * 100);
            isGround = false;
            //Gravity();
            Debug.Log("JUMP");
        }
        
    }
    /*
    private void Gravity()
    {
        rigid.AddForce(Vector2.down * gravityPower * 20);

    }
    */
    private void GroundCheck()
    {
        if (rigid.velocity.y < 0)
        {
            isGround = Physics2D.OverlapCircle(ground.position, 0.3f, whatIsGround); // 반지름이 0.2인 원에 ground가 닿으면 isGround를 true로 바꿔주는것

        }
    }
    private void BoxCheck()
    {
        if (rigid.velocity.y < 0)
        {
            isBox = Physics2D.OverlapCircle(ground.position, 0.3f, whatIsBox);
            /*
            if(Physics2D.Raycast(transform.position,Vector2.down, 10f,out hit)){
                
            }
            */
        }
    }
    public void CreateBox()
    {
        if (DataManager.instance.isPlaying && canBox > 0)
        {
            if (!isBox)
            {

                var boxObj = PoolManager.instance.GetObject();
                boxObj.transform.position = new Vector3(this.transform.position.x + (this.gameObject.transform.localScale.x + 0.5f), this.transform.position.y + 0.5f, this.transform.position.z);

                boxObj.transform.SetParent(map.transform);
                canBox--;
            }
            else
            {

                var boxObj = PoolManager.instance.GetObject();
                boxObj.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, this.transform.position.z);
                this.gameObject.transform.position = new Vector3(
                    this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z
                );

                boxObj.transform.SetParent(map.transform);
                canBox--;
            }
        }


    }

    private void Awake()
    {
        audioSource = FindObjectOfType<AudioSource>();
        Init();
    }
    private void Update()
    {
        if (DataManager.instance.isPlaying)
        {
            GroundCheck();
            BoxCheck();
        }
        /*
        if(Input.GetKeyDown(KeyCode.S))
            Jump();
        */
    }
    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("T")){
            this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
        if(col.gameObject.CompareTag("SPIKE")){
            DataManager.instance.isPlaying = false;
            //플레이어 애니메이션 재생
            stageManager.GameResult(false);
            SceneManager.LoadScene("ClearOver");
        }
    }
    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("JUMP")){
            Jump();
            Debug.Log("JuMP");
        }
        if(col.gameObject.CompareTag("BOX_ADD")){
            canBox++;
            col.gameObject.SetActive(false);
        }
    }
}
