using UnityEngine;

public static class GameObjectExtensions
{
    public static bool HasComponent<T>(this GameObject gameObject)
    {
        return gameObject.TryGetComponent<T>(out T component);
    }

    public static bool HasComponent<T>(this GameObject gameObject, out T component)
    {
        return gameObject.TryGetComponent<T>(out component);
    }

    public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
    {
        if (gameObject.TryGetComponent<T>(out T result))
        {
            return result;
        }
        else
        {
            return gameObject.AddComponent<T>();
        }
    }
}
