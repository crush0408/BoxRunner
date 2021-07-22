using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    public Transform setting;

    // Start is called before the first frame update
    void Start()
    {
        setting.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenSetting()
    {
        setting.DOScale(new Vector3(1, 1, 1), 0.2f);
    }
    public void CloseSetting()
    {
        setting.DOScale(new Vector3(0, 0, 0), 0.2f);
    }
}
