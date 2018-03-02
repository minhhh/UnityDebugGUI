using UnityEngine;
using System;
using System.Collections.Generic;

namespace DGUI
{
    public class DebugGUI : MonoBehaviour
    {
        protected static GUIScaler _guiScaler;
        protected static Rect _lastRect;
        static Dictionary <Type, string[]> _enumToStringArray = new Dictionary <Type, string[]> ();

        public static GUIScaler GUIScaler {
            get {
                if (_guiScaler == null) {
                    _guiScaler = new GUIScaler ();
                }
                return _guiScaler;
            }
        }

        private static GUIStyle _middleCenterLabelStyle;

        public static GUIStyle MiddleCenterLabelStyle {
            get {
                if (_middleCenterLabelStyle == null) {
                    _middleCenterLabelStyle = new GUIStyle (GUI.skin.label);
                    _middleCenterLabelStyle.alignment = TextAnchor.MiddleCenter;
                    _middleCenterLabelStyle.fontSize = (int)DebugGUI.GUIScaler.Convert (20);
                }
                return _middleCenterLabelStyle;
            }
        }

        private static GUIStyle _middleLeftLabelStyle;

        public static GUIStyle MiddleLeftLabelStyle {
            get {
                if (_middleLeftLabelStyle == null) {
                    _middleLeftLabelStyle = new GUIStyle (GUI.skin.label);
                    _middleLeftLabelStyle.alignment = TextAnchor.MiddleLeft;
                    _middleLeftLabelStyle.fontSize = (int)DebugGUI.GUIScaler.Convert (20);
                }
                return _middleLeftLabelStyle;
            }
        }

        private static GUIStyle _middleRightLabelStyle;

        public static GUIStyle MiddleRightLabelStyle {
            get {
                if (_middleRightLabelStyle == null) {
                    _middleRightLabelStyle = new GUIStyle (GUI.skin.label);
                    _middleRightLabelStyle.alignment = TextAnchor.MiddleRight;
                    _middleRightLabelStyle.fontSize = (int)DebugGUI.GUIScaler.Convert (20);
                }
                return _middleRightLabelStyle;
            }
        }

        private static GUIStyle _middleCenterTitleStyle;

        public static GUIStyle MiddleCenterTitleStyle {
            get {
                if (_middleCenterTitleStyle == null) {
                    _middleCenterTitleStyle = new GUIStyle (GUI.skin.button);
                    _middleCenterTitleStyle.alignment = TextAnchor.MiddleCenter;
                    _middleCenterTitleStyle.fontSize = (int)DebugGUI.GUIScaler.Convert (20);
                }
                return _middleCenterTitleStyle;
            }
        }

        private static GUIStyle _middleLeftTitleStyle;

        public static GUIStyle MiddleLeftTitleStyle {
            get {
                if (_middleLeftTitleStyle == null) {
                    _middleLeftTitleStyle = new GUIStyle (GUI.skin.button);
                    _middleLeftTitleStyle.alignment = TextAnchor.MiddleLeft;
                    _middleLeftTitleStyle.fontSize = (int)DebugGUI.GUIScaler.Convert (20);
                }
                return _middleLeftTitleStyle;
            }
        }

        private static GUIStyle _middleRightTitleStyle;

        public static GUIStyle MiddleRightTitleStyle {
            get {
                if (_middleRightTitleStyle == null) {
                    _middleRightTitleStyle = new GUIStyle (GUI.skin.button);
                    _middleRightTitleStyle.alignment = TextAnchor.MiddleRight;
                    _middleRightTitleStyle.fontSize = (int)DebugGUI.GUIScaler.Convert (20);
                }
                return _middleRightTitleStyle;
            }
        }

        public static Rect GetLastRect ()
        {
            if (Event.current.type == EventType.Repaint) {
                _lastRect = GUILayoutUtility.GetLastRect ();
            }
            return GUIScaler.ReversedConvert (_lastRect);
        }

        public static void DrawArea (Rect area, Action drawContent)
        {
            area = GUIScaler.Convert (area);

            GUI.Box (area, string.Empty);
            GUILayout.BeginArea (area);

            if (drawContent != null)
                drawContent ();

            GUILayout.EndArea ();
        }

        public static void DrawArea (Rect area, string title, Action drawContent)
        {
            area = GUIScaler.Convert (area);

            GUI.Box (area, string.Empty);
            GUILayout.BeginArea (area);

            DrawCenterTitle (title);
            GUILayout.Space (5);

            if (drawContent != null)
                drawContent ();

            GUILayout.EndArea ();
        }

        public static Vector2 DrawScrollView (Vector2 scrollPosition, Action drawContent)
        {
            scrollPosition = GUILayout.BeginScrollView (scrollPosition);
            if (drawContent != null)
                drawContent ();
            GUILayout.EndScrollView ();
            return scrollPosition;
        }

        public static Vector2 DrawScrollView (Rect screenRect, Vector2 scrollPosition, Action drawContent)
        {
            GUILayout.BeginArea (GUIScaler.Convert (screenRect));
            scrollPosition = DrawScrollView (scrollPosition, drawContent);
            GUILayout.EndArea ();
            return scrollPosition;
        }

        public static void DrawCenterTextLine (string text, GUIStyle style = null, params GUILayoutOption[] options)
        {
            GUILayout.BeginHorizontal ();
            GUILayout.FlexibleSpace ();
            GUILayout.Label (text, style ?? MiddleCenterLabelStyle, options);
            GUILayout.FlexibleSpace ();
            GUILayout.EndHorizontal ();
        }

        public static void DrawLeftTextLine (string text, GUIStyle style = null, params GUILayoutOption[] options)
        {
            GUILayout.BeginHorizontal ();
            GUILayout.Space (5);
            GUILayout.Label (text, style ?? MiddleLeftLabelStyle, options);
            GUILayout.FlexibleSpace ();
            GUILayout.EndHorizontal ();
        }

        public static void DrawRightTextLine (string text, GUIStyle style = null, params GUILayoutOption[] options)
        {
            GUILayout.BeginHorizontal ();
            GUILayout.FlexibleSpace ();
            GUILayout.Label (text, style ?? MiddleRightLabelStyle, options);
            GUILayout.Space (5);
            GUILayout.EndHorizontal ();
        }

        public static void DrawCenterTitle (string text, GUIStyle style = null, params GUILayoutOption[] options)
        {
            GUILayout.BeginHorizontal ();
            GUILayout.Label (text, style ?? MiddleCenterTitleStyle , options);
            GUILayout.EndHorizontal ();
        }

        public static void DrawLeftTitle (string text, GUIStyle style = null, params GUILayoutOption[] options)
        {
            GUILayout.BeginHorizontal ();
            GUILayout.Space (5);
            GUILayout.Label (text, style ?? MiddleLeftTitleStyle, options);
            GUILayout.EndHorizontal ();
        }

        public static void DrawRightTitle (string text, GUIStyle style = null, params GUILayoutOption[] options)
        {
            GUILayout.BeginHorizontal ();
            GUILayout.Label (text, style ?? MiddleRightTitleStyle, options);
            GUILayout.Space (5);
            GUILayout.EndHorizontal ();
        }

        public static void DrawLabelField (string label, string text, GUIStyle style = null, GUILayoutOption[] labelOptions = null, GUILayoutOption[] textOptions = null)
        {
            GUILayout.BeginHorizontal ();
            GUILayout.Space (5);
            GUILayout.Label (label, style ?? MiddleLeftLabelStyle, labelOptions);
            GUILayout.Label (text, style ?? MiddleLeftLabelStyle, textOptions);
            GUILayout.Space (5);
            GUILayout.EndHorizontal ();
        }

        public static string DrawTextField (string label, string text = null, GUIStyle labelStyle = null)
        {
            GUILayout.BeginHorizontal ();
            GUILayout.Space (5);
            if (text == null) {
                label = GUILayout.TextField (label);
            } else {
                GUILayout.Label (label, labelStyle ?? MiddleLeftLabelStyle);
                text = GUILayout.TextField (text);
            }
            GUILayout.Space (5);
            GUILayout.EndHorizontal ();

            return text ?? label;
        }

        public static bool DrawEnumButton (Type enumType, ref int index, params GUILayoutOption[] options)
        {
            bool clicked = false;

            if (!_enumToStringArray.ContainsKey (enumType)) {
                var values = Enum.GetValues (enumType);
                _enumToStringArray [enumType] = new string[values.Length];
                for (int i = 0; i < values.Length; i++) {
                    _enumToStringArray [enumType] [i] = values.GetValue (i).ToString ();
                }
            }

            if (GUILayout.Button (_enumToStringArray [enumType] [index])) {
                clicked = true;
                index += 1;
                index = index % _enumToStringArray [enumType].Length;
            }


            return clicked;
        }
    }

}