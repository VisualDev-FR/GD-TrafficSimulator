using System.Collections;
using System.Collections.Generic;
using Godot;

public static class GDUtils
{
    public static T FindChild<T>(Node root) where T : Node
    {
        foreach (Node child in root.GetChildren())
        {
            if (child is T)
            {
                return child as T;
            }

            if (FindChild<T>(child) is T node)
            {
                return node;
            }
        }

        return null;
    }

    public static T FindChild<T>(Node root, string name) where T : Node
    {
        foreach (Node child in root.GetChildren())
        {
            if (child is T && child.Name == name)
            {
                return child as T;
            }

            if (FindChild<T>(child, name) is T node && node.Name == name)
            {
                return node;
            }
        }

        return null;
    }

    public static IEnumerable<T> GetChildren<T>(Node parent)
    {
        foreach (var child in parent.GetChildren())
        {
            if (child is T validChild)
            {
                yield return validChild;
            }
        }
    }

    public static void SetMouseMode(Input.MouseModeEnum mouseMode)
    {
        Input.MouseMode = mouseMode;
    }

    public static string AbsolutePath(string path)
    {
        return ProjectSettings.GlobalizePath(path);
    }

}