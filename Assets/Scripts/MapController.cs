using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public float tempo;
    public float beatsPerSec;
    public bool hasStarted;
    public static float hiSpeed = 2.0f;

    // Start is called before the first frame update
    void Start() {
        beatsPerSec = tempo / 60f;
    }

    // Update is called once per frame
    void Update() {
        if (hasStarted && Time.time - GameManager.instance.timeGameStart >= PlaySettings.latency) {
            transform.position -= new Vector3(0f, beatsPerSec * Time.deltaTime * hiSpeed, 0f);
        }
    }
}
