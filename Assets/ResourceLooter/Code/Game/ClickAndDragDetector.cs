using UnityEngine;

namespace ResourceLooter
{
    public class ClickAndDragDetector
    {
        private readonly InputReceiver _inputReceiver;

        public ClickAndDragDetector(InputReceiver inputReceiver)
        {
            _inputReceiver = inputReceiver;
        }

        public event ScreenPositionHandler Clicked;
        public event ScreenPositionHandler DragStarted;
        public event ScreenPositionHandler Dragging;
        public event ScreenPositionHandler DragFinished;

        public void Enable()
        {
            _inputReceiver.MovePressed += MovePressedEventHandler;
            _inputReceiver.PointerPositionChanged += PointerPositionChangedEventHandler;
        }

        public void Disable()
        {
            _inputReceiver.MovePressed -= MovePressedEventHandler;
            _inputReceiver.PointerPositionChanged -= PointerPositionChangedEventHandler;
        }

        private void MovePressedEventHandler()
        {
        }

        private void PointerPositionChangedEventHandler(Vector2 position)
        {
        }
    }
}