using System;
using UnityEngine;

namespace HyperSpace
{
    public class HyperSpaceTunnelMove : MonoBehaviour
    {
        public float speed;

        public Vector3 startPos;

        private void OnEnable()
        {
            transform.position = startPos;
        }

        // Update is called once per frame
        private void Update()
        {
            transform.Translate(0f, 0f, speed);
        }
    }
}