using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    private bool hasHit = false;
    // 正确击打时间点
    private float timing;
    // 音符落点Y坐标
    private float spawnPointY = 4.6f;

    // Start is called before the first frame update
    void Start() {

    }

    public void SetTiming(float timing) {
        this.timing = timing;
    }

    // Update is called once per frame
    void Update() {
        // 当音符在没有到达记分板下方之前先隐藏音符，观感更好
        Renderer renderer = gameObject.GetComponent<Renderer>();
        if (transform.position.y > spawnPointY) {
            if (renderer.enabled) {
                renderer.enabled = false;
            }
        } else {
            if (!renderer.enabled) {
                renderer.enabled = true;
            }
        }
        if (Input.GetKeyDown(keyToPress)) {
            if (canBePressed) {
                gameObject.SetActive(false);
                GameManager.instance.NoteHit(
                    Time.time - GameManager.instance.timeGameStart,
                    timing
                );
                hasHit = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Activator") {
            canBePressed = true;
        } else if (other.tag == "Finish") {
            if (!hasHit) {
                GameManager.instance.NoteMissed();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Activator") {
            canBePressed = false;
        }
    }
}
