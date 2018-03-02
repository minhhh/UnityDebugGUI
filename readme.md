# UnityDebugGUI

> UnityDebugGUI is Common helpers for creating Debug GUI using the old GUI

When creating in-game debug function for Unity. It's much better to use old Unity rather than the new UGUI. `UnityDebugGUI` provides a quick way to draw common debug UI elements.

## Usage

Then main UI elements are:

1. Area (DrawArea): An area with semitransparent black background
2. ScrollView (DrawScrollView): A vertical scrollview
3. Center/Left/RightTextLine (DrawCenter/Left/RightTextLine): A simple line aligned at the center/left/right
4. Center/Left/RightTitle (DrawCenter/Left/RightTitle): A text line with button style aligned at the center/left/right. Usually used for showing the title of an area.
5. Label Field (DrawLabelField): A name label and content label, like in a form
6. TextField (DrawTextField): A label and a text field, like in a form
7. EnumButton (DrawEnumButton): A button which gets its label from an enum. When you click the button it will go to the next value in the enum.

When passing `Rect` parameter to functions like `DrawArea`, `DrawScrollView`, note that the value should be scaled to screen with the width equals 640. Currently, only portrait screen orientation is supported.

**API**

```
DGUI.DebugGUI.DrawArea (Rect area, string title, Action drawContent)
DGUI.DebugGUI.DrawScrollView (Vector2 scrollPosition, Action drawContent)
DGUI.DebugGUI.DrawScrollView (Rect screenRect, Vector2 scrollPosition, Action drawContent)
DGUI.DebugGUI.DrawCenterTextLine (string text, params GUILayoutOption[] options)
DGUI.DebugGUI.DrawLeftTextLine (string text, params GUILayoutOption[] options)
DGUI.DebugGUI.DrawRightTextLine (string text, params GUILayoutOption[] options)
DGUI.DebugGUI.DrawCenterTitle (string text, params GUILayoutOption[] options)
DGUI.DebugGUI.DrawLeftTitle (string text, params GUILayoutOption[] options)
DGUI.DebugGUI.DrawRightTitle (string text, params GUILayoutOption[] options)
DGUI.DebugGUI.DrawLabelField (string label, string text, GUILayoutOption[] labelOptions = null, GUILayoutOption[] textOptions = null)
DGUI.DebugGUI.DrawTextField (string label, string text = null)
DGUI.DebugGUI.DrawEnumButton (Type enumType, ref int index, params GUILayoutOption[] options)
```

## Examples

DebugGUI.DrawArea (new Rect (0, 0, 640, 500), "My Area", () => {
    DebugGUI.DrawCenterTextLine ("Center");
    DebugGUI.DrawLeftTextLine ("Left");
    DebugGUI.DrawRightTextLine ("Right");
    DebugGUI.DrawLeftTitle ("Left");
    DebugGUI.DrawRightTitle ("Right");
});

## Install
To include UnityDebugGUI into your project, you can use `npm` method of unity package management described [here](https://github.com/minhhh/UBootstrap).

## Changelog

**0.0.6**

* Support Unity 5.4

**0.0.5**

* Scale font size of labels and add external style

**0.0.4**

* Improve `DrawArea`
* Create readme

**0.0.3**

* Improve `DrawArea`

**0.0.2**

* Refactor

**0.0.1**

* Initial commit

<br/>

