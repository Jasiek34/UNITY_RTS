using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class OverlayTile : MonoBehaviour
    {
        public int H;
        public int G;
        public int F { get { return H+G; } }

        public bool isBlocked;
        public OverlayTile previousTile;

        public Vector3Int gridLocation;

        // Update is called once per frame
        void Update()
        {

        }
    }
}