using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public int key = 0;
    public int cur_index = 0;
    public bool isClear;
    public int appleCount;
    public int totalAppleCount;
    public float achievement;
    public float BGMmasterSoundVolume;
    public float EFFmasterSoundVolume;
    public bool isLeftHand = false;
    public bool isPlaying = true;
    public int myStageLevel = 1;
    public int boxSkinIndex = 0;
    

    void Awake()
    {
        MGSound.instance.init();
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        Load();
        
    }
    void Start()
    {
        if (!PlayerPrefs.HasKey("BGM"))
        {
            PlayerPrefs.SetFloat("BGM", 0.5f);
        }
        BGMmasterSoundVolume = PlayerPrefs.GetFloat("BGM");


        if (!PlayerPrefs.HasKey("EFF"))
        {
            PlayerPrefs.SetFloat("EFF", 0.5f);
        }
        EFFmasterSoundVolume = PlayerPrefs.GetFloat("EFF");

        if (!PlayerPrefs.HasKey("BOXSKIN"))
        {
            PlayerPrefs.SetInt("BOXSKIN", 0);
        }
        boxSkinIndex = PlayerPrefs.GetInt("BOXSKIN");
        /*
        int a = PlayerPrefs.GetInt("SetHeart"); 
        if(a == 0){
            Debug.Log("SetHeart");
            PlayerPrefs.SetInt("SetHeart", 1);
            m_HeartAmount = MAX_HEART;
            PlayerPrefs.Save();
        }
        else if(a != 0){
            Debug.Log("Already set Heart");
            m_HeartAmount = PlayerPrefs.GetInt("HeartAmount");
            Debug.Log(m_HeartAmount);
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            print("Q");
            Save();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            print("w");
            Load();
        }
        
        

    }
    public void Save()
    {
        PlayerPrefs.SetInt("KEY", key);
    }
    public void Load()
    {
        print(PlayerPrefs.GetInt("KEY"));
        if (!PlayerPrefs.HasKey("KEY"))
        {
            PlayerPrefs.SetInt("KEY", 0);
        }
        key = PlayerPrefs.GetInt("KEY");
    }
    
}


