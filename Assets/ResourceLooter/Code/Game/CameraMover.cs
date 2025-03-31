using UnityEngine;

namespace ResourceLooter
{
    public class CameraMover
    {
        private readonly ClickAndDragDetector _clickAndDragDetector;
        private readonly Transform _camera;

        public CameraMover(ClickAndDragDetector clickAndDragDetector, Transform camera)
        {
            _clickAndDragDetector = clickAndDragDetector;
            _camera = camera;
        }

        public void Enable()
        {
            _clickAndDragDetector.DragStarted += DragStartedEventHandler;
            _clickAndDragDetector.Dragging += DraggingEventHandler;
            _clickAndDragDetector.DragFinished += DragFinishedEventHandler;
        }

        public void Disable()
        {
            _clickAndDragDetector.DragStarted -= DragStartedEventHandler;
            _clickAndDragDetector.Dragging -= DraggingEventHandler;
            _clickAndDragDetector.DragFinished -= DragFinishedEventHandler;
        }

        private void DragStartedEventHandler(Vector2 screenPosition)
        {
        }

        private void DraggingEventHandler(Vector2 screenPosition)
        {
        }

        private void DragFinishedEventHandler(Vector2 screenPosition)
        {
        }
    }
}