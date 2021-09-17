using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public float Horizontal => _inputVector.x;
    public float Vertical => _inputVector.y;

    [SerializeField] private Image _background;
    [SerializeField] private Image _handle;

    private Vector2 _inputVector;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _background.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out localPos))
        {
            localPos.x = (localPos.x / _background.rectTransform.sizeDelta.x);
            localPos.y = (localPos.y / _background.rectTransform.sizeDelta.y);

            _inputVector = new Vector2(localPos.x * 2 - 1, localPos.y * 2 - 1);
            _inputVector = (_inputVector.magnitude > 1.0f) ? _inputVector.normalized : _inputVector;

            _handle.rectTransform.anchoredPosition = new Vector2(
                _inputVector.x * (_background.rectTransform.sizeDelta.x / 2),
                _inputVector.y * (_background.rectTransform.sizeDelta.y / 2)
                );
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _inputVector = Vector2.zero;
        _handle.rectTransform.anchoredPosition = Vector2.zero;
    }
}
