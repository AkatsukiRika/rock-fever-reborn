using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlaySettings {
    /**
     * 延迟秒数
     * 若音频比谱面快，将此值设定为负数，音频将延后播放，谱面中的判定时间将提前；
     * 若谱面比音频快，将此值设定为正数，谱面将延后播放，谱面中的判定时间将延后；
     */
    public static float latency = 0.150f;
}