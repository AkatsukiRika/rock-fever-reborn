using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance;
    public AudioSource soundSource;

    void Start() {
        instance = this;
    }

    public void PlaySound(string name) {
        AudioClip clip = Resources.Load<AudioClip>(name);
        soundSource.clip = clip;
        soundSource.PlayOneShot(clip);
    }

    // 游戏中的所有音效存放路径
    public static class AudioInfo {
        public const string VOICE_ACHIEVE_50 = "Voices/achieve_50";
        public const string VOICE_ACHIEVE_70 = "Voices/achieve_70";
        public const string VOICE_ACHIEVE_90 = "Voices/achieve_90";
        public const string VOICE_ACHIEVE_95 = "Voices/achieve_95";
        public const string VOICE_ACHIEVE_100 = "Voices/achieve_100";
    }
}
