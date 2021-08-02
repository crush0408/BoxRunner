using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public GameObject gear;
    public GameObject map;
    public Transform movePos;
    public bool isMove = false;
    public bool isLeft = false;
    public int moveSpeed = 3;

    [Header("회전속도 조절")]
    [SerializeField] [Range(1f, 100f)] float rotateSpeed = 50f;
    void Start()
    {
        this.gameObject.transform.SetParent(map.transform);
        movePos.gameObject.transform.SetParent(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
            if(isLeft){
                gear.transform.Rotate(0, 0, Time.deltaTime * rotateSpeed, Space.Self);
            }
            else{

                gear.transform.Rotate(0, 0, -Time.deltaTime * rotateSpeed, Space.Self);
            }
        if(isMove){

            gear.transform.position = Vector3.Lerp(gear.transform.position,movePos.position, moveSpeed * Time.deltaTime);
            gear.transform.Rotate(Vector3.left,Time.deltaTime);
            
        }
        
    }
    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("PLAYER")){
            isMove = true;
            
        }
    }
}
