using UnityEngine;

public class HighlightController : MonoBehaviour
{
    private Camera _camera;
    private HighlightableObject _lastHighlightedObject;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        // Получаем объект, на который указывает курсор
        var currentHighlightedObject = GetSelectedHighlightableObject();

        var isNewObject = currentHighlightedObject != _lastHighlightedObject;
        // Если это новый объект (не ранее подсвеченный)
        if (isNewObject)
        {
            if (_lastHighlightedObject != null)
            {
                // Убираем подсветку ранее подсвеченному тайлу
                _lastHighlightedObject.ResetColor();
            }
            
            // Если объект, на который указывает мышь, есть (это подсвечиваемый тайл)
            if (currentHighlightedObject != null)
            {
                // Подсвечиваем его
                currentHighlightedObject.Highlight();
            }
            
            // Сохраняем текущий подсвечиваемый объект в поле
            _lastHighlightedObject = currentHighlightedObject;
        }
    }

    private HighlightableObject GetSelectedHighlightableObject()
    {
        // Получает позицию курсора
        var mousePosition = Input.mousePosition;
        // Переводим позицию курсора в луч из этой точки экрана в мировое пространство
        var ray = _camera.ScreenPointToRay(mousePosition);

        // Если луч пересекает какой-либо коллайдер
        if (Physics.Raycast(ray, out var hitInfo))
        {
            // Получаем у коллайдера компонент HighlightableObject и возвращаем его
            var highlightableObject = hitInfo.collider.GetComponent<HighlightableObject>();
            return highlightableObject;
        }

        return null;
    }
}
