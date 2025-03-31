using UnityEngine;

namespace ResourceLooter
{
    public class ClickAndDragDetector
    {
        private readonly InputReceiver _inputReceiver;
        private Vector2 _lastScreenPosition;
        private bool _isButtonPressed;
        private bool _isDragging;

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

        private void MovePressedEventHandler(bool isPressed)
        {
            _isButtonPressed = isPressed;
            if (_isButtonPressed == false)
            {
                ClickOrFinishDrag();
            }
        }

        private void ClickOrFinishDrag()
        {
            if (_isDragging)
            {
                _isDragging = false;
                DragFinished?.Invoke(_lastScreenPosition);
            }
            else
            {
                Clicked?.Invoke(_lastScreenPosition);
            }
        }

        private void PointerPositionChangedEventHandler(Vector2 position)
        {
            _lastScreenPosition = position;
        }
    }
}