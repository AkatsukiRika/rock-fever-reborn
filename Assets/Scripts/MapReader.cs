using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Beatmap {
    public string title;
    public string artist;
    public int tempo;
    public int signature;
    public string level;
    public int barCount;
    public Note[] notes;
}

[Serializable]
public class Note {
    public int len;
    public int pos;
}

public class MapReader : MonoBehaviour
{
    public Text modeText1P;
    public Text songNameText;
    
    // 游戏中使用的音符游标
    public GameObject[] notes;
    public Transform noteHolder;

    // 小节线
    public GameObject barLine;

    // 音符正确时机相关
    public List<float> timingList;
    private float timePerBeat;
    private float timePerBar;

    // 音符位置相关
    private Dictionary<int, float> dictNoteX;
    private float distancePerBeat = 1.0f;
    private float distancePerBar;
    private float judgeLineY = -4.35f;
    private float barLineX = -6.8f;

    // 整个乐谱
    private Beatmap beatmap;

    // 判定区域
    public GameObject judgeLine1P;
    private const float defaultColliderSizeY = 2.5f;

    public void ReadBeatmap() {
        // 初始化音符横坐标字典
        dictNoteX = new Dictionary<int, float>();
        dictNoteX.Add(3, -9.2f);
        dictNoteX.Add(1, -8.4f);
        dictNoteX.Add(4, -7.6f);
        dictNoteX.Add(7, -6.8f);
        dictNoteX.Add(5, -6.0f);
        dictNoteX.Add(2, -5.2f);
        dictNoteX.Add(6, -4.4f);

        // 设置hiSpeed
        distancePerBeat = PlaySettings.hiSpeed;
        BoxCollider2D judgeLineCollider1P = judgeLine1P.GetComponent<BoxCollider2D>();
        judgeLineCollider1P.size = new Vector2(1.0f, defaultColliderSizeY * PlaySettings.hiSpeed);

        // 初始化音符时间列表
        timingList = new List<float>();

        string jsonStr = Resources.Load<TextAsset>("Beatmaps/bm003_fever").ToString();
        beatmap = JsonUtility.FromJson<Beatmap>(jsonStr);
        // 设置PlaySettings
        PlaySettings.tempo = beatmap.tempo;
        PlaySettings.signature = beatmap.signature;
        // 设置界面上需显示的曲目相关元素
        songNameText.text = beatmap.title;
        modeText1P.text = "PRO / Lv." + beatmap.level;
        GameResult.instance.songName = songNameText.text;
        GameResult.instance.gameMode = modeText1P.text;
        // 设置参数
        distancePerBar = distancePerBeat * beatmap.signature;
        timePerBeat = 60f / beatmap.tempo;
        timePerBar = timePerBeat * beatmap.signature;
        // 开始读取音符
        float currentPosY = judgeLineY;
        float currentTiming = PlaySettings.latency;
        int noteCount = 0;
        foreach(var note in beatmap.notes) {
            int pos = note.pos;
            int len = note.len;
            GameObject noteObject;
            if (pos != 0) {
                // 支持多键同时押
                int[] posArr = RFUtils.GetIntArray(pos);
                for (int i = 0; i < posArr.Length; i++) {
                    int posThis = posArr[i];
                    noteObject = Instantiate(
                        notes[posThis - 1],
                        new Vector3(dictNoteX[posThis], currentPosY, 0f),
                        Quaternion.identity,
                        noteHolder
                    );
                    var noteController = noteObject.GetComponent<NoteController>();
                    noteController.SetTiming(currentTiming);
                    timingList.Add(currentTiming);
                    noteCount++;
                }
            }
            currentPosY += distancePerBar / len;
            currentTiming += timePerBar / len;
        }
        GameManager.instance.SetTotalNotes(noteCount);
        GameResult.instance.totalNote = noteCount;

        // 生成小节线
        GenerateBarLine();

        // 每5秒钟切换难度和BPM显示
        InvokeRepeating("ChangeModeText", 2, 2);
    }

    /**
     * 根据乐曲的拍号及BPM生成小节线的方法
     */
    void GenerateBarLine() {
        for (int i = 0; i < beatmap.barCount; i++) {
            Instantiate(
                barLine,
                new Vector3(barLineX, i * distancePerBar + judgeLineY, 0f),
                Quaternion.identity,
                noteHolder
            );
        }
    }

    void ChangeModeText() {
        if (modeText1P.text.Contains("Lv.")) {
            modeText1P.text = "BPM: " + beatmap.tempo;
        } else if (modeText1P.text.Contains("BPM")) {
            modeText1P.text = "PRO / Lv." + beatmap.level;
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
