using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DGUI
{
    public class GUIScaler
    {
        private float _scale;
        private const int DefaultBaseWidth = 640;

        public GUIScaler (int baseWidth = 640)
        {
            _scale = (float)Screen.width / baseWidth;
        }

        public float Convert (float size)
        {
            return size * _scale;
        }

        public Vector2 Convert (Vector2 size)
        {
            return new Vector2 (Convert (size.x), Convert (size.y));
        }

        public Rect Convert (Rect rect)
        {
            return new Rect (Convert (rect.x), Convert (rect.y), Convert (rect.size.x), Convert (rect.size.y));
        }

    }

}