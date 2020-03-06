using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Entity;
using MyBox;

public class TileGrid : MonoSingleton<TileGrid> {

    #region STRUCT_GridLayout

    private readonly struct GridLayout { 
        internal int CameraSize { get; }

        internal int GridSize { get; }

        internal GridLayout(int cameraSize, int gridSize) =>
            (CameraSize, GridSize) = (cameraSize, gridSize);

        internal static GridLayout FromGridSetup(GridSetup gridSetup) {
            switch (gridSetup) {
                case GridSetup.Three_By_Three:
                    return new GridLayout(5, 3);
                case GridSetup.Five_By_Five:
                    return new GridLayout(8, 5);
                case GridSetup.Seven_By_Seven:
                    return new GridLayout(11, 7);
                default:
                    return new GridLayout(5, 3);
            }
        }
    }

    #endregion

    [Separator("DEBUG")]
    [SerializeField]
    private GridSetup gridSetup;

    [Separator("Tiles Setup")]
    [SerializeField, Tooltip("Prefab for the tile"), MustBeAssigned]
    private Tile tilePrefab;

    [SerializeField, Min(0f), Tooltip("How far are each tile apart from one another")]
    private float offset;

    private Dictionary<GridPoint, Tile> gridmap;

    protected override void OnAwake() {
        
    }

    private void Start() {
        CreateGrid();
    }

    private void CreateGrid() {
        Camera mainCamera = Camera.main;
        GridLayout gridLayout = GridLayout.FromGridSetup(gridSetup);
        mainCamera.orthographicSize = gridLayout.CameraSize;

        gridmap = new Dictionary<GridPoint, Tile>();

        Vector2 startPos = GetScreenCenter();
        float tileLength = tilePrefab.GetLength();

        for (int x = GetBottomRightPoint().X; x <= GetTopLeftPoint().X; ++x) {
            for (int y = GetBottomRightPoint().Y; y <= GetTopLeftPoint().Y; ++y) {

                GridPoint currPoint = new GridPoint(x, y);

                if (!gridmap.ContainsKey(currPoint)) {
                    Tile currTile = CreateTileAtPoint(currPoint);
                    gridmap.Add(currPoint, currTile);
                }

            }
        }


        #region Local_Function

        GridPoint GetTopLeftPoint() {
            int xPoint = Mathf.FloorToInt(gridLayout.GridSize / 2f);
            int yPoint = Mathf.FloorToInt(gridLayout.GridSize / 2f);

            return new GridPoint(xPoint, yPoint);
        }

        GridPoint GetBottomRightPoint() {
            int xPoint = -Mathf.FloorToInt(gridLayout.GridSize / 2f);
            int yPoint = -Mathf.FloorToInt(gridLayout.GridSize / 2f);

            return new GridPoint(xPoint, yPoint);
        }

        Tile CreateTileAtPoint(GridPoint point) {
            Tile newTile = Instantiate(tilePrefab);

            // negative or positive
            //int xSign = (point.X > 0) ? 1 : -1;
            //int ySign = (point.Y > 0) ? 1 : -1;

            float xPos = ((tileLength * point.X) + (point.X * offset)) + startPos.x;
            float yPos = ((tileLength * point.Y) + (point.Y * offset)) + startPos.y;

            newTile.transform.position = new Vector2(xPos, yPos);
            newTile.Initalize(point);

            return newTile;
        }

        Vector2 GetScreenCenter() {
            return mainCamera.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
        }

        #endregion
    }

    internal bool TryGetTile(GridPoint point, out Tile tile) {
        tile = null;

        if (gridmap.ContainsKey(point)) {
            tile = gridmap[point];
        }

        return tile != null;
    }
}
