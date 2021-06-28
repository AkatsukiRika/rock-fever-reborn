using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongSelectManager : MonoBehaviour {
    // 代表选中态的粉色圆圈
    public GameObject songSelectedHover;
    // 6首乐曲的GameObject位置
    public Transform[] songObjectPosArr;
    // 当前选择的是第几首乐曲（从0开始计数）
    private int curActiveSong = 0;
    // 剩余时间
    private float timeRemain = 99.99f;
    public Text timeText;

    // Start is called before the first frame update
    void Start() {
        
    }

    void Update() {
        // 进行倒计时
        if (timeRemain > 0) {
            timeRemain -= Time.deltaTime;
            timeText.text = string.Format("{0:N2}", timeRemain);
        }
        // 按下红色按钮1
        if (Input.GetKeyDown(KeyCode.D)) {
            moveSongCursor(-1);
        }
        // 按下红色按钮2
        if (Input.GetKeyDown(KeyCode.K)) {
            moveSongCursor(1);
        }
    }

    private void moveSongCursor(int amount) {
        if (curActiveSong >= 0 && curActiveSong <= 5) {
            if (curActiveSong == 0 && amount < 0) {
                return;
            } else if (curActiveSong == 5 && amount > 0) {
                return;
            } else {
                curActiveSong += amount;
                songSelectedHover.transform.position = songObjectPosArr[curActiveSong].position;
            }
        }
    }
}
