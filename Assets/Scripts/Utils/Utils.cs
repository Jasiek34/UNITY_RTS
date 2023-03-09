using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    public static class Utils
    {
        public static  Vector3 GetPozycjaMyszy()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
