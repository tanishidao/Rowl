using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SoundManager : MonoBehaviour
{
    public AudioSource AudioBGMSource;
    public AudioSource[] AudioSESource = new AudioSource[3];

    // Start is called before the first frame update

    private string BGMPath = "Assets/Sound/BGM/";
    private string SEPath = "Assets/Sound/SE/";
    private string MP3Extention = ".mp3";

    /// <summary>
    /// ���g�̃C���X�^����
    /// </summary>
    private static SoundManager instance;
    /// <summary>
    /// ���g�̃C���X�^���X�ւ̃A�N�Z�X
    /// </summary>
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (SoundManager)FindObjectOfType(typeof(SoundManager));
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    instance = go.AddComponent<SoundManager>();
                    go.name = instance.GetType().ToString();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }
    public void PlaySESound(string SoundName)
    {
        for (int i = 0; i < 3; i++)
        {
            if (AudioSESource[i] == null)
            {
                AudioSESource[i] = this.gameObject.AddComponent<AudioSource>();
            }
            if (!AudioSESource[i].isPlaying)
            {
                Addressables.LoadAssetAsync<AudioClip>(SEPath + SoundName + MP3Extention).Completed += op =>
                {
                    AudioSESource[i].clip = op.Result;
                    AudioSESource[i].Play();
                };
                break;
            }
        }
    }
    public void PlayBGMSound(string SoundName)
    {
        if (AudioBGMSource == null)

        {
            AudioBGMSource = this.gameObject.AddComponent<AudioSource>();
        }
        if (!AudioBGMSource.isPlaying)
        {
            Addressables.LoadAssetAsync<AudioClip>(BGMPath + SoundName + MP3Extention).Completed += op =>
            {
                AudioBGMSource.clip = op.Result;
                AudioBGMSource.Play();
            };
        }
    }

}
