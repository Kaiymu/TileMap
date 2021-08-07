using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class HighlightTile : MonoBehaviour
{
    protected Tilemap _tileMap;

    private void Awake()
    {
        _tileMap = GetComponent<Tilemap>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseCoordinates = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var cellCoordinates = _tileMap.WorldToCell(mouseCoordinates);
            var tileClicked = _tileMap.GetTile<Tile>(cellCoordinates);

            if (tileClicked == null)
                return;

            TileClicked(tileClicked, cellCoordinates);
        }
    }

    protected abstract void TileClicked(Tile tileClicked, Vector3Int cellCoordinates);
}
