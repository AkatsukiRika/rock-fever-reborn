using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource audioSource;
    public bool playbackStarted;
    public MapReader mapReader;
    public MapController mapController;
    public LyricsReader lyricsReader;
    public static GameManager instance;
    public int currentScore;
    public float maxScore;
    public Text percentageText;
    public float timeGameStart;
    
    // 判定等级
    private const float expertRange = 20f;
    private const float greatRange = 50f;
    private const float coolRange = 80f;
    private const float niceRange = 100f;

    // 根据判定等级而定的计分标准
    private const int scorePerExpertNote = 2600;
    private const int scorePerGreatNote = 2500;
    private const int scorePerCoolNote = 2000;
    private const int scorePerNiceNote = 1250;

    // 当前连击数
    private int currentCombo = 0;
    public Text comboText;
    // 连击数只在画面上展示3秒，3秒内没有按下一个音符的话会消失
    private const float COMBO_APPEAR_TIME = 0.5f;
    private float comboTimer = COMBO_APPEAR_TIME;

    // Start is called before the first frame update
    void Start() {
        instance = this;
    }

    // Update is called once per frame
    void Update() {
        if (!playbackStarted) {
            if (Input.anyKeyDown) {
                playbackStarted = true;
                mapController.hasStarted = true;

                audioSource.Play();
                percentageText.text = "0.0000 %";
                mapReader.ReadBeatmap();
                lyricsReader.StartPlayingLyrics();

                timeGameStart = Time.time;
                comboClear(false);
            }
        } else {
            comboTimer -= Time.deltaTime;
            if (comboTimer <= 0) {
                comboText.text = "";
            }
            // 若音乐播放完毕，跳转到结算场景
            if (!audioSource.isPlaying) {
                GameResult.instance.totalScore = currentScore;
                GameResult.instance.rate = (currentScore / maxScore) * 100;
                SceneManager.LoadScene("ResultScene");
            }
            // 测试代码，请删除
            if (Input.GetKeyDown(KeyCode.T)) {
                GameResult.instance.totalScore = currentScore;
                GameResult.instance.rate = (currentScore / maxScore) * 100;
                SceneManager.LoadScene("ResultScene");
            }
        }
    }

    public void NoteHit(float hitTiming, float correctTiming) {
        float accuracy = hitTiming - correctTiming;
        if (Mathf.Abs(accuracy * 1000) < expertRange) {
            currentScore += scorePerExpertNote;
            comboAndJudgeUpdate("EXPERT");
            GameResult.instance.expertCount++;
        } else if (Mathf.Abs(accuracy * 1000) < greatRange) {
            currentScore += scorePerGreatNote;
            comboAndJudgeUpdate("Great");
            GameResult.instance.greatCount++;
        } else if (Mathf.Abs(accuracy * 1000) < coolRange) {
            currentScore += scorePerCoolNote;
            comboAndJudgeUpdate("Cool");
            GameResult.instance.coolCount++;
        } else if (Mathf.Abs(accuracy * 1000) < niceRange) {
            currentScore += scorePerNiceNote;
            comboAndJudgeUpdate("Nice");
            GameResult.instance.niceCount++;
        } else {
            comboClear();
            GameResult.instance.poorCount++;
        }
        percentageUpdate(currentScore);
    }

    public void NoteMissed() {
        comboClear();
        GameResult.instance.poorCount++;
    }

    public void SetTotalNotes(int noteCount) {
        maxScore = noteCount * scorePerGreatNote;
    }

    private void percentageUpdate(int score) {
        float currentPercentage = (score / maxScore) * 100;
        string currentStr = string.Format("{0:N4}", currentPercentage);
        percentageText.text = currentStr + " %";
    }

    private void comboAndJudgeUpdate(string judgeClass) {
        currentCombo++;
        if (currentCombo > GameResult.instance.maxCombo) {
            GameResult.instance.maxCombo = currentCombo;
        }
        comboText.text = currentCombo.ToString() + "\n" + judgeClass;
        comboTimer = COMBO_APPEAR_TIME;
    }

    private void comboClear(bool isPoor = true) {
        currentCombo = 0;
        if (isPoor) {
            comboText.text = "\nPoor";
        } else {
            comboText.text = "";
        }
        comboTimer = COMBO_APPEAR_TIME;
    }
}
