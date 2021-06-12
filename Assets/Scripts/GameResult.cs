using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult : MonoBehaviour
{
    public static GameResult instance { get; private set; }
    // 需要传到结算界面的信息
    public string gameMode;
    public string songName;
    public int totalNote;
    public int expertCount = 0;
    public int greatCount = 0;
    public int coolCount = 0;
    public int niceCount = 0;
    public int poorCount = 0;
    public int maxCombo = 0;
    public int totalScore;
    public float rate;

    // Start is called before the first frame update
    void Start() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
}
