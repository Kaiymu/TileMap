using Gameplay.Tower;
using UnityEngine;

public class DragManager : MonoBehaviour
{
    public LayerMask _layerDrag;
    public LayerMask _layerDrop;

    private BasicTower _towerDragged;
    private Transform _previousParent;

    private void _OnMouseEnter (Vector2 screenToWorld)
    {
        if (Input.GetMouseButtonDown(0))
        {
            var raycast = Physics2D.Raycast(screenToWorld, Vector2.down, Mathf.Infinity, _layerDrag);

            if (raycast.collider != null)
            {
                _towerDragged = raycast.transform.GetComponent<BasicTower>();
                _towerDragged.GetComponent<BoxCollider2D>().enabled = false;

                _previousParent = _towerDragged.transform.parent.transform;
                _towerDragged.transform.parent = null;
            }
        }
    }

    private void Update()
    {
        Vector2 mouseToWorldPos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);

        _OnMouseEnter(mouseToWorldPos);

        if (_towerDragged == null)
            return;
            
        _towerDragged.transform.position = mouseToWorldPos;
        _OnMouseUnpress(mouseToWorldPos);
    }

    private void _OnMouseUnpress(Vector2 screenToWorld)
    {
        if (Input.GetMouseButtonUp(0))
        {
            var raycast = Physics2D.Raycast(screenToWorld, Vector2.down, Mathf.Infinity, _layerDrop);

            if (raycast.collider != null)
            {
                var towerDrop = raycast.transform.GetComponent<TowerDrop>();

                if(towerDrop.TryUpdateBasicTower(_towerDragged))
                {
                    _towerDragged.transform.position = towerDrop.transform.position;
                    _towerDragged.transform.parent = towerDrop.transform;
                } else
                {
                    _towerDragged.transform.position = _previousParent.position;
                    _towerDragged.transform.parent = _previousParent.transform;
                }
            }
            else
            {
                _towerDragged.transform.position = _previousParent.position;
                _towerDragged.transform.parent = _previousParent.transform;
            }

            _InvalidateTowerDrag();
        }
    }
    
    private void _InvalidateTowerDrag()
    {
        _towerDragged.GetComponent<BoxCollider2D>().enabled = true;
        _towerDragged = null;
    }
}

