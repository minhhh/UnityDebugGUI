using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DGUI
{
    public class GUIScaler
    {
        public const int DefaultBaseWidth = 640;

        private float _scale;

        public GUIScaler (int baseWidth = DefaultBaseWidth)
        {
            _scale = (float)Screen.width / baseWidth;
        }

        // Convert from Base to Screen
        public float Convert (float size)
        {
            return size * _scale;
        }

        // Convert from Screen to Base
        public float ReversedConvert (float size)
        {
            return size / _scale;
        }

        public Vector2 Convert (Vector2 size)
        {
            return new Vector2 (Convert (size.x), Convert (size.y));
        }

        public Rect Convert (Rect rect)
        {
            return new Rect (Convert (rect.x), Convert (rect.y), Convert (rect.size.x), Convert (rect.size.y));
        }

        public Vector2 ReversedConvert (Vector2 size)
        {
            return new Vector2 (ReversedConvert (size.x), ReversedConvert (size.y));
        }

        public Rect ReversedConvert (Rect rect)
        {
            return new Rect (ReversedConvert (rect.x), ReversedConvert (rect.y), ReversedConvert (rect.size.x), ReversedConvert (rect.size.y));
        }

    }

}