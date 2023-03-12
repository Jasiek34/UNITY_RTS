using System;
using System.Collections;
using UnityEngine;
using Pathfinding;

namespace Assets.Scripts

{
    public interface IMovePosition
    {
        void SetMovePosition(Vector3 movePosition, Action onReachedMovePosition);
    }

    public class MovePosition : MonoBehaviour, IMovePosition
    {
        private AIPath aiPath;
        void Awake()
        {
            aiPath = GetComponent<AIPath>();
        }
        public void SetMovePosition(Vector3 movePosition, Action onReachedMovePosition)
        {
            aiPath.destination= movePosition;

        }
    }
}