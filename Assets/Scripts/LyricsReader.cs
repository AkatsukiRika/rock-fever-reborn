using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LyricsReader : MonoBehaviour
{
    public Dictionary<float, string> lyrics;
    public Text lyricsText;
    private List<float> timingList;
    private int currentIndex;

    // Start is called before the first frame update
    void Start() {
        lyrics = new Dictionary<float, string>();
        timingList = new List<float>();
        
        // 读取LRC文件
        string lrcStr = Resources.Load<TextAsset>("Lyrics/rc001").ToString();
        string[] delimiter = new string[] { "\n" };
        string[] lrcLines = lrcStr.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < lrcLines.Length; i++) {
            Regex regex = new Regex(@"\[([0-9.:]*)\]+(.*)", RegexOptions.Compiled);
            MatchCollection matches = regex.Matches(lrcLines[i]);
            float time = (float) TimeSpan.Parse("00:" + matches[0].Groups[1].Value).TotalSeconds;
            string words = matches[0].Groups[2].Value;
            lyrics.Add(time, words);
            timingList.Add(time);
        }

        // 初始状态：不显示歌词文字
        lyricsText.text = "";
    }

    public void StartPlayingLyrics() {
        foreach (float key in lyrics.Keys) {
            Invoke("ChangeLyricsOnUI", key);
        }
    }

    void ChangeLyricsOnUI() {
        float timing = timingList[currentIndex++];
        lyricsText.text = lyrics[timing];
    }
}
