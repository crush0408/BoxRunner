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

    public bool isPlaying = true;
    void Awake()
    {
        MGSound.instance.init();
        DontDestroyOnLoad(this);
        instance = this;
        Load();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
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
        key = PlayerPrefs.GetInt("KEY");
    }
}
