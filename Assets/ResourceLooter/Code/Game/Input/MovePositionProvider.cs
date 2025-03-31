using System;
using UnityEngine;

namespace ResourceLooter
{
    public class MovePositionProvider
    {
        private readonly InputReceiver _inputReceiver;

        public MovePositionProvider(InputReceiver inputReceiver)
        {
            _inputReceiver = inputReceiver;
        }

        public event Action<Vector3> PositionChanged;

        public void Enable()
        {
            _inputReceiver.MovePressed += MovePressedEventHandler;
        }

        public void Disable()
        {
            _inputReceiver.MovePressed -= MovePressedEventHandler;
        }

        private void MovePressedEventHandler()
        {
            Debug.Log(nameof(MovePressedEventHandler));
            PositionChanged?.Invoke(Vector3.zero);
        }
    }
}