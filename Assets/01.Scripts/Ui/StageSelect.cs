using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class StageSelect : MonoBehaviour
{
    public int index = 0;
    public Transform GoalPos;
    public Text StageNum;
    public Transform StartPos;
    public Transform Player;
    public RectTransform[] Stages;
    public Image[] StagesIMG;
    Sequence Stage;
    public Toggle toggle;
    public GameObject cannotStage;
    void Start()
    {
        
        StageStart();
        toggle.isOn = DataManager.instance.isLeftHand;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            HeartManager.Instance.m_HeartAmount = 10;
            HeartManager.Instance.m_RechargeRemainTime = 0;
        }
        StageInfo();
        PlayerMove();
    }
    void PlayerMove()
    {
        Player.transform.position = Vector3.MoveTowards(Player.transform.position, GoalPos.transform.position, 1.5f * Time.deltaTime);
        if (Vector3.Distance(Player.transform.position, GoalPos.transform.position) <= 0.1f)
        {
            Player.transform.position = StartPos.transform.position;
        }
    }

    public void nextStage() //버튼 기능 (오른쪽)
    {
        index += 1;
        if (index >= 1)
        {
            index = 1;
        }
        /*
        if (index >= 3)
        {
            index = 3;
        }
        */
        Debug.Log(index);

    }
    public void backStage() //버튼 기능 (왼쪽)
    {
        index -= 1;
        if (index < 0)
        {
            index = 0;
        }
        Debug.Log(index);


    }
    public void StageStart() //닷트윈 시퀀스
    {
        Stage.Kill();
        Stage = DOTween.Sequence();

    }

    public void StageInfo() //스테이지 선택시 스테이지창 효과
    {
        float StageScore = 0;
        if (DataManager.instance.key < index)
        {
            cannotStage.SetActive(true);
        }
        else
        {
            cannotStage.SetActive(false);
        }
        if (index == 0)
        {
            StageScore = 1;
            StageNum.text = StageScore.ToString();
            
        }
        if (index == 1)
        {
            StageScore = 2;
            StageNum.text = StageScore.ToString();

        }
        if (index == 2)
        {
            StageScore = 3;
            StageNum.text = StageScore.ToString();
        }
        if (index == 3)
        {
            StageScore = 4;
            StageNum.text = StageScore.ToString();

        }
        // if (index == 4)
        // {

        //     for (int i = 0; i <= 4; i++)
        //     {
        //         Stages[i].DOScale(new Vector3(0.75f, 0.75f, 0.75f), 1);
        //         if (i == 0)
        //         {
        //             Stages[0].DOScale(new Vector3(0,0,0), 0.4f);

        //         }
        //         if(i == 1)
        //         {
        //            // Stages[1].DOMoveX(272,0.5f);
        //             Stages[1].DOScale(new Vector3(0.75f,0.75f,0.75f), 0.5f);
        //         }
        //         if(i == 2)
        //         {
        //            // Stages[2].DOMoveX(544,0.5f);
        //         }
        //         if(i == 3)
        //         {
        //            // Stages[3].DOMoveX(816,0.5f);

        //         }
        //         if (i == 4)
        //         {
        //            // Stages[4].DOMoveX(1100,0.5f);
        //           //  Stages[4].DOScale(new Vector3(1, 1, 1), 1);
        //         }
        //     }
        // }
    }

    public void TouchStage()
    {
       if(DataManager.instance.key >= index && HeartManager.Instance.m_HeartAmount > 0)
        {
            
            DataManager.instance.cur_index = index + 2;
            HeartManager.Instance.OnClickUseHeart();

            GameObject a = Instantiate(HeartManager.Instance.heartResumePanel);
            a.transform.SetParent(this.gameObject.transform, false);
            StartCoroutine(HeartPanel());
            

        }
        else if(DataManager.instance.key >= index )
        {
            GameObject a = Instantiate(HeartManager.Instance.heartlowPanel);
            a.transform.SetParent(this.gameObject.transform, false);
        }

    }
    public void GoMain()
    {
        SceneManager.LoadScene("StartGame");
    }
    /*
    public void SelectStage() //스테이지 선택
    {
        for (int i = 0; i < 4; i++)
        {
            if (index == i)
            {
                SceneManager.LoadScene(i+2);
                DataManager.instance.cur_index = index;
            }
        }
    }
    */
    public void LeftHandMode()
    {
        DataManager.instance.isLeftHand = toggle.isOn;
        //DataManager.instance.isLeftHand = !DataManager.instance.isLeftHand;
        Debug.Log(DataManager.instance.isLeftHand);
    }
    IEnumerator HeartPanel()
    {
        Debug.Log("gd");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(index + 2);
    }
}
