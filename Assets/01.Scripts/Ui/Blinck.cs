using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinck : MonoBehaviour
{
    float time;

    // Update is called once per frame
    void Update()
    {
        if (time < 0.5f)
        {
            GetComponent<Text>().color = new Color(0, 0, 0, 1 - time);
        }
        else
        {
            GetComponent<Text>().color = new Color(0, 0, 0, time);
            if (time > 1f)
            {
                time = 0;
            }
        }

        time += Time.deltaTime;

    }
}