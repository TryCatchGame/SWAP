using UnityEngine;

[System.Serializable]
#pragma warning disable CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
public readonly struct GridPoint {
#pragma warning restore CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
#pragma warning restore CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)

    internal int X { get; }

    internal int Y { get; }

    internal GridPoint(int x, int y) => (X, Y) = (x, y);

    public static bool operator ==(GridPoint a, GridPoint b) => (a.X, a.Y) == (b.X, b.Y);

    public static bool operator !=(GridPoint a, GridPoint b) => (a.X, a.Y) != (b.X, b.Y);

    public static GridPoint operator +(GridPoint a, GridPoint b) => new GridPoint(a.X + b.X, a.Y + b.Y);

    public static GridPoint operator -(GridPoint a, GridPoint b) => new GridPoint(a.X - b.X, a.Y - b.Y);

    public static implicit operator GridPoint(Vector2Int vector) => new GridPoint(vector.x, vector.y);

    public static implicit operator Vector2Int(GridPoint point) => new Vector2Int(point.X, point.Y);
}
