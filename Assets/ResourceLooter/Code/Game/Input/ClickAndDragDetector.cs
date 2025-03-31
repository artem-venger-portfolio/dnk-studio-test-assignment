using UnityEngine;

namespace ResourceLooter
{
    public class ClickAndDragDetector
    {
        private readonly InputReceiver _inputReceiver;
        private Vector2 _lastScreenPosition;
        private Vector2 _movePressPosition;
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
            if (_isButtonPressed)
            {
                RecordMovePressPosition();
            }
            else
            {
                ClickOrFinishDrag();
            }
        }

        private void RecordMovePressPosition()
        {
            _movePressPosition = _lastScreenPosition;
        }

        private void ClickOrFinishDrag()
        {
            if (_isDragging)
            {
                StopDragging();
            }
            else
            {
                Clicked?.Invoke(_lastScreenPosition);
            }
        }

        private void StopDragging()
        {
            _isDragging = false;
            DragFinished?.Invoke(_lastScreenPosition);
        }

        private void PointerPositionChangedEventHandler(Vector2 position)
        {
            _lastScreenPosition = position;

            if (CanStartDragging())
            {
                StartDragging();
            }

            if (CanInvokeDraggingEvent())
            {
                Dragging?.Invoke(_lastScreenPosition);
            }
        }

        private bool CanStartDragging()
        {
            return _isButtonPressed && _isDragging == false && IsDragDistanceExceedThreshold();
        }

        private bool IsDragDistanceExceedThreshold()
        {
            var dragDistance = Vector2.Distance(_movePressPosition, _lastScreenPosition);
            const float drag_threshold = 10f;
            var isDragDistanceExceedThreshold = dragDistance < drag_threshold;

            return isDragDistanceExceedThreshold;
        }

        private void StartDragging()
        {
            _isDragging = true;
            DragStarted?.Invoke(_movePressPosition);
        }

        private bool CanInvokeDraggingEvent()
        {
            return _isButtonPressed && _isDragging;
        }
    }
}