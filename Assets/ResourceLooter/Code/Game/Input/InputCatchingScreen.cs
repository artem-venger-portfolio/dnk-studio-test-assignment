using UnityEngine;
using UnityEngine.EventSystems;

namespace ResourceLooter
{
    public class InputCatchingScreen : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        public event ScreenPositionHandler Clicked;
        public event ScreenPositionHandler DragStarted;
        public event ScreenPositionHandler Dragging;
        public event ScreenPositionHandler DragFinished;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            Clicked?.Invoke(eventData.position);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            DragStarted?.Invoke(eventData.pressPosition);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            DragFinished?.Invoke(eventData.position);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Dragging?.Invoke(eventData.position);
        }
    }
}