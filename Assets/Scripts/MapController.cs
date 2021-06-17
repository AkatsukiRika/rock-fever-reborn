using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapController : MonoBehaviour {
    public float beatsPerSec;
    public bool hasStarted;

    // Update is called once per frame
    void Update() {
        if (PlaySettings.tempo != 0.0f && beatsPerSec == 0.0f) {
            beatsPerSec = PlaySettings.tempo / 60f;
        }
        if (hasStarted && Time.time - GameManager.instance.timeGameStart >= PlaySettings.latency) {
            transform.position -= new Vector3(0f, beatsPerSec * Time.deltaTime * PlaySettings.hiSpeed, 0f);
        }
    }
}
