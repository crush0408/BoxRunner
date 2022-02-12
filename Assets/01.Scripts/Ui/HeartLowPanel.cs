using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartLowPanel : MonoBehaviour
{
    public Text remainText;
    private void Update()
    {
        remainText.text = $"하트 충전까지 {HeartManager.Instance.m_RechargeRemainTime}초 남았습니다.";
        if(HeartManager.Instance.m_HeartAmount > 0)
        {
            ClosePanel();
        }
    }
    public void ClosePanel()
    {
        Destroy(this.gameObject);
    }
}
