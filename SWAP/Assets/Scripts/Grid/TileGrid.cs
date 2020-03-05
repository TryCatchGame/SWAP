using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Entity;
using MyBox;

public class TileGrid : MonoSingleton<TileGrid> {

    [Separator("DEBUG")]
    [SerializeField]
    private int gridSize;

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
            int xPoint = Mathf.FloorToInt(gridSize / 2f);
            int yPoint = Mathf.FloorToInt(gridSize / 2f);

            return new GridPoint(xPoint, yPoint);
        }

        GridPoint GetBottomRightPoint() {
            int xPoint = -Mathf.FloorToInt(gridSize / 2f);
            int yPoint = -Mathf.FloorToInt(gridSize / 2f);

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
            Camera camera = Camera.main;

            return camera.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
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
