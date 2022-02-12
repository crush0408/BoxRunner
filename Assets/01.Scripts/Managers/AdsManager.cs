using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    public GameObject cannotShowPanel, rewardPanel, cannotSeePanel; 
    
    public void ShowReward()
    {
        if (Advertisement.IsReady("rewardedVideo") && HeartManager.Instance.m_HeartAmount < 10)
        {
            ShowOptions options = new ShowOptions { resultCallback = ResultAds };
            Advertisement.Show("rewardedVideo", options);
        }
        else
        {
            Debug.Log("No");
            cannotSeePanel.SetActive(true);
        }
    }

    void ResultAds(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:
                Debug.LogError("NoADS");
                cannotShowPanel.SetActive(true);
                break;
            case ShowResult.Skipped:
                Debug.LogError("ADS_Skipped");
                cannotShowPanel.SetActive(true);
                break;
            case ShowResult.Finished:
                HeartManager.Instance.m_HeartAmount++;
                rewardPanel.SetActive(true);
                break;
            
        }
    }
}
