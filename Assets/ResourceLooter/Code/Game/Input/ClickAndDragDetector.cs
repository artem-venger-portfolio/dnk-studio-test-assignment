using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ResourceLooter
{
    public class ClickAndDragDetector
    {
        private readonly InputReceiver _inputReceiver;
        private readonly IGameConfig _gameConfig;
        private Vector2 _lastScreenPosition;
        private Vector2 _movePressPosition;
        private bool _isButtonPressed;
        private bool _isDragging;

        public ClickAndDragDetector(InputReceiver inputReceiver, IGameConfig gameConfig)
        {
            _inputReceiver = inputReceiver;
            _gameConfig = gameConfig;
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
                if (IsPointerOverUI() == false)
                {
                    Clicked?.Invoke(_lastScreenPosition);
                }
            }
        }

        private bool IsPointerOverUI()
        {
            var eventSystem = EventSystem.current;
            var eventData = new PointerEventData(eventSystem)
            {
                position = _lastScreenPosition,
            };
            var results = new List<RaycastResult>();
            eventSystem.RaycastAll(eventData, results);

            return results.Count > 0;
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
            var isDragDistanceExceedThreshold = dragDistance < _gameConfig.DragThreshold;

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