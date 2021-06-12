using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSceneManager : MonoBehaviour
{
    public Text songName;
    public Text gameMode1P;
    public Text totalNote1P;
    public Text expertCount1P;
    public Text greatCount1P;
    public Text coolCount1P;
    public Text niceCount1P;
    public Text poorCount1P;
    public Text maxCombo1P;
    public Text totalScore1P;
    public Text rate1P;
    public Text rankText1P;

    // 评分等级相关
    public static class RankInfo {
        public static string RANK_SS_NAME = "牛牛";
        public static float RANK_SS_BORDER = 100f;
        public static string RANK_SPLUS_NAME = "陽+";
        public static float RANK_SPLUS_BORDER = 95f;
        public static string RANK_S_NAME = "陽";
        public static float RANK_S_BORDER = 90f;
        public static string RANK_APLUS_NAME = "蘭";
        public static float RANK_APLUS_BORDER = 80f;
        public static string RANK_A_NAME = "洲";
        public static float RANK_A_BORDER = 70f;
        // 以下的评分等级将算作过关失败
        public static string RANK_B_NAME = "洲-";
        public static float RANK_B_BORDER = 50f;
        public static string RANK_C_NAME = "敗+";
        public static float RANK_C_BORDER = 30f;
        public static string RANK_D_NAME = "敗";
    }

    // 是否过关的显示
    public Text stageResultText;

    // Start is called before the first frame update
    void Start() {
        songName.text = GameResult.instance.songName;
        gameMode1P.text = GameResult.instance.gameMode;
        totalNote1P.text = GameResult.instance.totalNote.ToString();
        expertCount1P.text = GameResult.instance.expertCount.ToString();
        greatCount1P.text = GameResult.instance.greatCount.ToString();
        coolCount1P.text = GameResult.instance.coolCount.ToString();
        niceCount1P.text = GameResult.instance.niceCount.ToString();
        poorCount1P.text = GameResult.instance.poorCount.ToString();
        maxCombo1P.text = GameResult.instance.maxCombo.ToString();
        totalScore1P.text = GameResult.instance.totalScore.ToString();
        rate1P.text = string.Format("{0:N4}", GameResult.instance.rate);

        showRank();
    }

    private void showRank() {
        float rate = GameResult.instance.rate;
        switch (rate) {
            case float r when (r > RankInfo.RANK_SS_BORDER):
                rankText1P.text = RankInfo.RANK_SS_NAME;
                break;
            case float r when (r > RankInfo.RANK_SPLUS_BORDER):
                rankText1P.text = RankInfo.RANK_SPLUS_NAME;
                break;
            case float r when (r > RankInfo.RANK_S_BORDER):
                rankText1P.text = RankInfo.RANK_S_NAME;
                break;
            case float r when (r > RankInfo.RANK_APLUS_BORDER):
                rankText1P.text = RankInfo.RANK_APLUS_NAME;
                break;
            case float r when (r > RankInfo.RANK_A_BORDER):
                rankText1P.text = RankInfo.RANK_A_NAME;
                break;
            case float r when (r > RankInfo.RANK_B_BORDER):
                rankText1P.text = RankInfo.RANK_B_NAME;
                break;
            case float r when (r > RankInfo.RANK_C_BORDER):
                rankText1P.text = RankInfo.RANK_C_NAME;
                break;
            default:
                rankText1P.text = RankInfo.RANK_D_NAME;
                break;
        }
        if (rate > RankInfo.RANK_A_BORDER) {
            stageResultText.text = "STAGE 1\nCLEAR !!";
        } else {
            stageResultText.text = "STAGE 1\nFAILED...";
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
