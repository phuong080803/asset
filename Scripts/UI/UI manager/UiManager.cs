using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : singleton<UiManager>
{
    [SerializeField] Transform parent;
    public GameObject losePanel;
    Dictionary<System.Type, UiCanvas> canvasActive = new Dictionary<System.Type, UiCanvas>();
    Dictionary<System.Type, UiCanvas> canvasPrefab = new Dictionary<System.Type, UiCanvas>();
    private void Awake()
    {
        UiCanvas[] prefab = Resources.LoadAll<UiCanvas>("UI/");
        for(int i = 0; i < prefab.Length; i++)
        {
            canvasPrefab.Add(prefab[i].GetType(), prefab[i]);
        }
        
        this.losePanel.SetActive(false);
    }

    public T Open<T>() where T : UiCanvas
    {
        T canvas = getUI<T>();
        canvas.Setup();
        canvas.Open();
        return canvas;
    }
    public void Close<T>(float time) where T : UiCanvas
    {
        if (isOpened<T>())
        {
            canvasActive[typeof(T)].Close(time);
        }
    }
    public void CloseDirectly<T>() where T : UiCanvas
    {
        if (isOpened<T>())
        {
            canvasActive[typeof(T)].CloseDirectly();
        }
    }
    public bool isLoad<T>() where T : UiCanvas
    {
        return canvasActive.ContainsKey(typeof(T)) && canvasActive[typeof(T)] !=null;
    } 
    public bool isOpened<T>() where T : UiCanvas
    {
        return isLoad<T>() && canvasActive[typeof(T)].gameObject.activeSelf;
    }
    public T getUI<T>() where T : UiCanvas
    {
        if (isLoad<T>())
        {
            T prefab = GetUIPrefab<T>(); 
            T canvas = Instantiate(prefab, parent);
            canvasActive[typeof(T)] = canvas;
        }
        return canvasActive[typeof(T)] as T;
    }
    private T GetUIPrefab<T>() where T : UiCanvas
    {
        return canvasPrefab[typeof(T)] as T; 
    }
    public void CloseAll()
    {
        foreach (var canvas in canvasActive)
        {
            if(canvas.Value != null && canvas.Value.gameObject.activeSelf)
            {
                canvas.Value.Close(0);
            }
        }
    }
}
