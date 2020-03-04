using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TappableObject : MonoBehaviour {
    internal delegate void OnTapped();

    internal OnTapped onTapped;

    internal void Tap() {
        onTapped?.Invoke();
    }
}
