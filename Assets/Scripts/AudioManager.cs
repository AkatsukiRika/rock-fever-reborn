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

        // result画面语音
        public const string RANK_SS_CLEAR = "Voices/rank_ss_clear";
        public const string RANK_SPLUS_CLEAR = "Voices/rank_splus_clear";
        public const string RANK_S_CLEAR = "Voices/rank_s_clear";
        public const string RANK_APLUS_CLEAR = "Voices/rank_aplus_clear";
        public const string RANK_A_CLEAR = "Voices/rank_a_clear";
        public const string RANK_B = "Voices/rank_b";
        public const string RANK_C = "Voices/rank_c";
        public const string RANK_D = "Voices/rank_d";
        public const string STAGE_CLEAR = "Voices/stage_clear";
        public const string STAGE_FAILED = "Voices/stage_failed";
    }
}
