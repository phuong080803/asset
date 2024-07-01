using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiCanvas : MonoBehaviour
{
    [SerializeField] bool isdestroyOnClose = false;
    private void Awake()
    {
        RectTransform rect = GetComponent<RectTransform>();
        float ratio = (float)Screen.width / (float)Screen.height;
        if (ratio > 2.1f)
        {
            Vector2 leftBottom = rect.offsetMin;
            Vector2 rightTop = rect.offsetMax;
            rect.offsetMin = leftBottom;
            rect.offsetMax = rightTop;
        }
    }
    public virtual void Setup()
    {

    }
    public virtual void Open()
    {
        gameObject.SetActive(true);
    }
    public virtual void Close(float time)
    {
        Invoke(nameof(CloseDirectly), time);
    }
    public virtual void CloseDirectly()
    {
        if (isdestroyOnClose)
        {
            Destroy(gameObject);
        }
        gameObject.SetActive(false);

    }
}
