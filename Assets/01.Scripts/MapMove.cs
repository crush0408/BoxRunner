using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 10f;
    void Start()
    {
        //Debug.Log(DataManager.instance.isPlaying);
    }

    // Update is called once per frame
    void Update()
    {
        if(DataManager.instance.isPlaying){
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
    }
}
