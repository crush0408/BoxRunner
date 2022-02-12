using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartLowPanel : MonoBehaviour
{
    public Text remainText;
    private void Update()
    {
        remainText.text = $"��Ʈ �������� {HeartManager.Instance.m_RechargeRemainTime}�� ���ҽ��ϴ�.";
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
