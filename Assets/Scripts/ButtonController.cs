using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Color defaultColor;
    public Color pressedColor;
    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(keyToPress)) {
            // 按下按钮
            spriteRenderer.color = pressedColor;
        }
        if (Input.GetKeyUp(keyToPress)) {
            // 放开按钮
            spriteRenderer.color = defaultColor;
        }
    }
}
