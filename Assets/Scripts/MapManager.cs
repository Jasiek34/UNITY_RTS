﻿using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts
{
    public class MapManager : MonoBehaviour
    {
        private static MapManager _instance;
        public static MapManager Instance { get { return _instance; } }

        public GameObject overlayPrefab;
        public GameObject overlayContainer;

        public Dictionary<Vector2Int, OverlayTile> map;
        

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            
            var tileMap = gameObject.GetComponentInChildren<Tilemap>();
            map = new Dictionary<Vector2Int, OverlayTile>();

            BoundsInt bounds = tileMap.cellBounds;
           
            for (int z = bounds.min.z; z >= bounds.min.z; z--)
            {
                for (int y = bounds.min.y; y < bounds.max.y; y++)
                {
                    
                    for (int x = bounds.min.x; x < bounds.max.x; x++)
                    {
                        
                        var tileLocation = new Vector3Int(x, y, z);
                        var tileKey = new Vector2Int(x, y);
                        if (tileMap.HasTile(tileLocation) && !map.ContainsKey(tileKey))
                        {
                            var overlayTile = Instantiate(overlayPrefab, overlayContainer.transform);
                            var cellWorldPosition = tileMap.GetCellCenterWorld(tileLocation);
                            overlayTile.transform.position = new Vector3(cellWorldPosition.x, cellWorldPosition.y, cellWorldPosition.z + 1);
                            overlayTile.GetComponent<SpriteRenderer>().sortingOrder = tileMap.GetComponent<TilemapRenderer>().sortingOrder;
                            overlayTile.gameObject.GetComponent<OverlayTile>().gridLocation = tileLocation;
                            map.Add(new Vector2Int(x, y), overlayTile.gameObject.GetComponent<OverlayTile>());
                        }
                        
                    }
                }
            }
            /*foreach (OverlayTile o in map.Values)
            {
                Debug.Log(o.gridLocation.ToString());
            }*/
        }
    }
}