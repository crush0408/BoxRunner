using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class IngameMenu : MonoBehaviour
{
    public GameObject TextPos;
    public Button StopButton;
    public Slider StageCurBar;
    StageManager stageManager;
    public Transform StopMenu;

    public Text delayText;

    // Start is called before the first frame update
    void Start()
    {
        StopMenu.transform.localScale = Vector3.zero;

    }
    void Awake()
    {
        stageManager = FindObjectOfType<StageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (DataManager.instance.isPlaying)
        {
            StageCur();
        }
    }

    void StageCur()
    {
        StageCurBar.value = stageManager._achievement * 100;
    }


    public void StopMenuOpen()
    {

        StopMenu.DOScale(new Vector3(1, 1, 1), 0.2f).OnComplete(delegate ()
        {
            //Time.timeScale = 0f;
            DataManager.instance.isPlaying = false;
        });
    }
    public void StopMenuClose()
    {
        //StopMenu.DOScale(new Vector3(0, 0, 0), 0.2f);

        StopMenu.DOScale(new Vector3(0, 0, 0), 0.2f).OnComplete(delegate ()
        {
            StartCoroutine(Delay());
        });

    }

    public void LoadEnding()
    {
        DataManager.instance.isPlaying = true;
        SceneManager.LoadScene("ClearOver");
    }
    public void Retry()
    {
        SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        //Time.timeScale = 1f;

    }
    IEnumerator Delay()
    {
        delayText.gameObject.SetActive(true);
        delayText.text = "3";
        yield return new WaitForSeconds(1f);
        delayText.text = "2";
        yield return new WaitForSeconds(1f);
        delayText.text = "1";
        yield return new WaitForSeconds(1f);
        delayText.gameObject.SetActive(false);
        DataManager.instance.isPlaying = true;
    }
}