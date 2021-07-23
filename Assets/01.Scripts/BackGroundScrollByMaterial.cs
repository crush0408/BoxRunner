using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScrollByMaterial : MonoBehaviour
{
    public float scrollSpeed = 0.5f;

    Material myMaterial;


	void Start ()

    {

        myMaterial = GetComponent<Renderer>().material;

		

	}



	void Update ()

    {
        if(DataManager.instance.isPlaying){

            float newOffsetX = myMaterial.mainTextureOffset.x + scrollSpeed * Time.deltaTime;

            Vector2 newOffset = new Vector2(newOffsetX, 0);



            myMaterial.mainTextureOffset = newOffset;
        }

		

	}
}
