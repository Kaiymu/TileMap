using Gameplay.Tower;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// TODO to delete, but first document
public class TowerConstruction : HighlightTile
{
    [SerializeField]
    private ArcherTower _archerTower;


    protected override void TileClicked(Tile tileClicked, Vector3Int cellCoordinates)
    {
        //_tileMap.SetTile(cellCoordinates, null);
        //var centerCell = _tileMap.GetCellCenterWorld(cellCoordinates);
    }
}
