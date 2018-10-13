using UnityEngine;

public static class GameObjectExtensions
{    
    /// <summary>Instantiates a copy of this gameobject</summary>
    public static GameObject Instantiate(this GameObject go)
    {
        return Object.Instantiate(go, go.transform.parent);
    }

    public static GameObject Instantiate(this GameObject go, Transform parent)
    {
        return Object.Instantiate(go, parent);
    }
}
