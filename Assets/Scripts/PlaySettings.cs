using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlaySettings {
    // 粗略测试得到的延迟数值
    public const float LATENCY_MACOS = 0.000f;
    public const float LATENCY_WIN = 0.150f;

    /**
     * 延迟秒数
     * 若音频比谱面快，将此值设定为负数，音频将延后播放，谱面中的判定时间将提前；
     * 若谱面比音频快，将此值设定为正数，谱面将延后播放，谱面中的判定时间将延后；
     */
    public static float latency = LATENCY_MACOS;

    /**
     * 乐曲的BPM（每分钟节拍数）
     */
    public static float tempo;

    /**
     * 乐曲的拍号（每个小节有多少个四分音符）
     */
    public static int signature;

    /**
     * 谱面流动速度，默认的1.0速为1个四分音符下落Unity中的1个单位
     */
    public static float hiSpeed = 3.0f;
}