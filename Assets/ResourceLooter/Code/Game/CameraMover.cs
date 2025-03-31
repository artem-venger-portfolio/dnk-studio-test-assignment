using System.Collections;
using UnityEngine;

namespace ResourceLooter
{
    public class CameraMover
    {
        private readonly ClickAndDragDetector _clickAndDragDetector;
        private readonly ICoroutineController _coroutineController;
        private readonly Transform _camera;
        private Coroutine _moveCoroutine;
        private bool _isDragging;

        public CameraMover(ClickAndDragDetector clickAndDragDetector, Transform camera,
                           ICoroutineController coroutineController)
        {
            _clickAndDragDetector = clickAndDragDetector;
            _coroutineController = coroutineController;
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
            _isDragging = true;
            RunMoveCoroutine();
        }

        private void RunMoveCoroutine()
        {
            if (_moveCoroutine != null)
            {
                _coroutineController.Stop(_moveCoroutine);
            }
            _moveCoroutine = _coroutineController.Run(GetMoveCoroutine());
        }

        private void DraggingEventHandler(Vector2 screenPosition)
        {
        }

        private void DragFinishedEventHandler(Vector2 screenPosition)
        {
            _isDragging = false;
        }

        private IEnumerator GetMoveCoroutine()
        {
            yield break;
        }
    }
}