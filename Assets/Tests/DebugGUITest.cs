using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DGUI;

public class DebugGUITest : MonoBehaviour
{
    Vector2 scrollPosition = Vector2.zero;
    string text1 = "text1";
    string text2 = "text2";
    bool toggle = false;
    int index = 0;

    enum Fruits {
        Orange,
        Apple
    }

    void OnGUI ()
    {
        DebugGUI.DrawArea (new Rect (0, 0, 640, 500), "My Area", () => {
            DebugGUI.DrawCenterTextLine ("Center");
            DebugGUI.DrawLeftTextLine ("Left");
            DebugGUI.DrawRightTextLine ("Right");
            DebugGUI.DrawLeftTitle ("Left");
            DebugGUI.DrawRightTitle ("Right");
        });

        DebugGUI.DrawArea (new Rect (0, 500, 100, 400), "ScrollView", () => {
            scrollPosition = DebugGUI.DrawScrollView (scrollPosition, () => {
                GUILayout.Space (15);
                DebugGUI.DrawCenterTextLine ("Center");
                GUILayout.Space (5);
                toggle = GUILayout.Toggle (toggle, "a");
                DebugGUI.DrawCenterTextLine ("Center");
                DebugGUI.DrawLeftTextLine ("Left");
                DebugGUI.DrawRightTextLine ("Right");
                DebugGUI.DrawLeftTitle ("Left");
                DebugGUI.DrawRightTitle ("Right");
                DebugGUI.DrawCenterTextLine ("Center");
                DebugGUI.DrawLeftTextLine ("Left");
                DebugGUI.DrawRightTextLine ("Right");
                DebugGUI.DrawLeftTitle ("Left");
                DebugGUI.DrawRightTitle ("Right");
                DebugGUI.DrawCenterTextLine ("Center");
                DebugGUI.DrawLeftTextLine ("Left");
                DebugGUI.DrawRightTextLine ("Right");
                DebugGUI.DrawLeftTitle ("Left");
                DebugGUI.DrawRightTitle ("Right");
            });
        });

        DebugGUI.DrawArea (new Rect (100, 500, 540, 400), "Form", () => {
            
            DebugGUI.DrawLabelField ("Label", "Value");
            text1 = DebugGUI.DrawTextField (text1);
            text2 = DebugGUI.DrawTextField ("name", text2);

            DebugGUI.DrawEnumButton (typeof (Fruits), ref index);
        });
    }
}
