using System;
using System.Collections.Generic;
using UnityEngine;
using com.github.lhervier.ksp.mcpserver;

namespace com.github.lhervier.ksp.diag.terrainheight
{
    /// <summary>
    /// What KSP-MCPServer, when it is installed, offers of this mod as tools: its buttons, the reading of
    /// its table, and the moving of its window. Each method works on the window loaded in the scene.
    /// Nothing here is needed to play by hand, and this mod runs the same without KSP-MCPServer: only
    /// that server reads the attribute.
    /// </summary>
    internal static class McpTools
    {
        [McpTool("terrainheight_record",
            "Presses Record in the window of KSP Diag - Terrain Height: freezes the line in progress into " +
                "its table, and returns it (CollisionSurfaceMm, ComputedTerrainMm, in millimetres above sea level).")]
        internal static object Record()
        {
            return Window().Record();
        }

        [McpTool("terrainheight_read",
            "Reads the window of KSP Diag - Terrain Height: its recorded lines and the line in " +
                "progress (CollisionSurfaceMm, ComputedTerrainMm, in millimetres above sea level).")]
        internal static object Read()
        {
            KSPDiagTerrainHeight window = Window();
            return new Dictionary<string, object>
            {
                { "lines", new List<Reading>(window.Lines) },
                { "live", window.Live }
            };
        }

        [McpTool("terrainheight_clear", "Presses Clear table in the window of KSP Diag - Terrain Height.")]
        internal static void Clear()
        {
            Window().Clear();
        }

        [McpTool("terrainheight_move_window",
            "Moves the window of KSP Diag - Terrain Height, as dragging it does: x and y in pixels from " +
            "the top left corner of the screen. Returns its position and size (x, y, width, height).")]
        internal static object MoveWindow(double x, double y)
        {
            KSPDiagTerrainHeight window = Window();
            Rect rect = window.WindowRect;
            rect.x = (float)x;
            rect.y = (float)y;
            window.WindowRect = rect;
            return new Dictionary<string, object>
            {
                { "x", (double)rect.x },
                { "y", (double)rect.y },
                { "width", (double)rect.width },
                { "height", (double)rect.height }
            };
        }

        // The window of this mod in the current scene; the window only exists in flight.
        private static KSPDiagTerrainHeight Window()
        {
            KSPDiagTerrainHeight window = UnityEngine.Object.FindObjectOfType<KSPDiagTerrainHeight>();
            if (window == null)
            {
                throw new InvalidOperationException("The window of KSP Diag - Terrain Height only exists in flight");
            }
            return window;
        }
    }
}
