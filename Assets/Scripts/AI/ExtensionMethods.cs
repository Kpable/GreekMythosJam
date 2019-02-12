using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public static class ExtensionMethods  {

    public static void FromArray<T>(this List<T> list, T[] array)
    {
        list.Clear();
        for (int i = 0; i < array.Length; i++)
        {
            list.Add(array[i]);
        }
        
    }

    // Bounds
    public static void DrawGizmo(this BoundsInt bounds)
    {
        Gizmos.DrawWireCube(bounds.position, bounds.size);
    }

    public static void DrawGizmo(this BoundsInt bounds, Vector3Int scale)
    {
        Vector3Int size = new Vector3Int(bounds.size.x * scale.x, 
            bounds.size.y * scale.y, 
            bounds.size.z * scale.z);
        Gizmos.DrawWireCube(bounds.position, size);
    }

    // Tilemap 

    public static bool HasTile(this Tilemap tilemap, int x, int y)
    {
        return tilemap.HasTile(new Vector3Int(x, y, 0));
    }

    public static Vector3 CellToWorld(this Tilemap tilemap, int x, int y)
    {
        return tilemap.CellToWorld(new Vector3Int(x, y, 0));
    }
}
