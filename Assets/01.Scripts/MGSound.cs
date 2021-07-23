using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EffectSource
{
    public AudioSource mySource;
    public string myName;
    public bool bPlayed;
}

public class MGSound : MonoBehaviour
{
    public Slider EffectVolume;
    public AudioSource soundSource;
    public GameObject[] _bgmObj;
    public GameObject[] _effObj;

    private Dictionary<string, AudioClip> _audioClipDic;
    private List<AudioSource> _bgmSource;
    private List<EffectSource> _effSource;

    private int _bgmIdx = 0;
    private int _effIdx = 0;

    private int _effMaxNum;
    public float masterSoundVolume;

    public static MGSound _instance;
    public static MGSound instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(MGSound)) as MGSound;
                if (_instance == null)
                {
                    GameObject obj = Instantiate(Resources.Load("Prefabs/ETC/MGSound", typeof(GameObject))) as GameObject;
                    _instance = obj.GetComponent<MGSound>();
                }
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        _bgmSource = new List<AudioSource>();
        _effSource = new List<EffectSource>();
        _audioClipDic = new Dictionary<string, AudioClip>();

        for (int i = 0; i < _bgmObj.Length; i++)
            _bgmSource.Add(_bgmObj[i].GetComponent<AudioSource>());

        _effMaxNum = _effObj.Length;
        for (int i = 0; i < _effMaxNum; i++)
        {
            EffectSource efs = new EffectSource();
            efs.mySource = _effObj[i].GetComponent<AudioSource>();
            efs.myName = "";
            efs.bPlayed = false;

            _effSource.Add(efs);
        }

        AudioClip[] audios = Resources.LoadAll<AudioClip>("Sound");

        for (int i = 0; i < audios.Length; i++)
            _audioClipDic.Add(audios[i].name, audios[i]);
    }
    public void PlaySound(float vol, AudioClip myClip)     //adjust preferred volume of particular clip in "vol" 
    {
        EffectVolume.value= soundSource.volume;
        soundSource.clip = myClip;
        soundSource.volume = masterSoundVolume * vol;
        soundSource.Play();
    }

    void OnEnable()
    {

    }

    public void init()
    {
        // Bgm
        /*
        if(PlayerPrefs.HasKey("BgmOn"))
        {
            Environments._bgmOn = PlayerPrefEx.getInt("BgmOn");
        }
        else
        {
            Environments._bgmOn = 1;
            PlayerPrefEx.setInt("BgmOn", Environments._bgmOn);
        }
        */

        // Eff
        /*
        if (PlayerPrefs.HasKey("EffOn"))
        {
            Environments._effOn = PlayerPrefEx.getInt("EffOn");
        }
        else
        {
            Environments._effOn = 1;
            PlayerPrefEx.setInt("EffOn", Environments._effOn);
        }
        */
    }

    public void playBgm(string bgmName)
    {
        //if (Environments._bgmOn == 0) return;

        _bgmIdx += 1;
        _bgmIdx %= 2;

        _bgmSource[_bgmIdx].clip = _audioClipDic[bgmName];
        _bgmSource[_bgmIdx].loop = true;
        _bgmSource[_bgmIdx].Play();

        StartCoroutine("crossBgm");
    }

    public void stopBgm()
    {
        _bgmSource[_bgmIdx].Stop();
    }

    public void playEff(string effName, float volume)
    {
        //if (Environments._effOn == 0) return;

        if (_effSource[_effIdx].bPlayed && !_effSource[_effIdx].mySource.isPlaying)
        {
            if (_effSource[_effIdx].myName.Equals(effName))
            {
                _effSource[_effIdx].bPlayed = false;
                return;
            }
        }

        //if (_effSource[_effIdx].bPlayed && !_effSource[_effIdx].mySource.isPlaying)
        //{
        //    _effSource[_effIdx].bPlayed = false;
        //}

        _effSource[_effIdx].myName = effName;
        _effSource[_effIdx].mySource.clip = _audioClipDic[effName];
        _effSource[_effIdx].mySource.loop = false;
        _effSource[_effIdx].mySource.volume = volume;
        _effSource[_effIdx].mySource.Play();
        _effSource[_effIdx].bPlayed = true;

        _effIdx++;
        if (_effIdx >= _effMaxNum) _effIdx = 0;
    }

    IEnumerator crossBgm()
    {
        float newVolumn = 0;
        int prevIdx = _bgmIdx - 1;

        if (prevIdx < 0)
            prevIdx = 1;

        while (newVolumn < 1)
        {
            newVolumn += Time.deltaTime;
            newVolumn = Mathf.Clamp(newVolumn, 0, 1);

            if (_bgmSource[prevIdx].clip != null)
            {
                _bgmSource[prevIdx].volume = (1 - newVolumn) / 2;
            }

            _bgmSource[_bgmIdx].volume = newVolumn / 2;

            yield return null;
        }
    }
}
