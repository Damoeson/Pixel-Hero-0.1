using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Core : MonoBehaviour
{
    public readonly List<CoreComponent> CoreComponents = new List<CoreComponent>();

    private void Awake()
    {
        // Find all core component children
        var comps = GetComponentsInChildren<CoreComponent>();

        // Add componets found to list. Use old function to avoid duplicates.
        foreach (var component in comps)
        {
            AddComponent(component);
        }

        // Call Init on each
        foreach (var component in CoreComponents)
        {
            component.Init(this);
        }
    }

    public void LogicUpdate()
    {
        foreach (CoreComponent component in CoreComponents)
        {
            component.LogicUpdate();
        }
    }

    public T GetCoreComponent<T>() where T : CoreComponent
    {
        var comp = CoreComponents
            .OfType<T>()
            .FirstOrDefault();

        if (comp == null)
        {
            Debug.LogWarning($"{typeof(T)} not found on {transform.parent.name}");
        }

        return comp;
    }

    public T GetCoreComponent<T>(ref T value) where T : CoreComponent
    {
        value = GetCoreComponent<T>();
        return value;
    }

    public void AddComponent(CoreComponent component)
    {
        if (!CoreComponents.Contains(component))
        {
            CoreComponents.Add(component);
        }
    }
}
