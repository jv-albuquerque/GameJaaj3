using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{
    private Tile lastTileHit = null;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Tile"))
                {
                    if (hit.collider.gameObject.GetComponent<Tile>() == lastTileHit)
                    {
                        lastTileHit.DeactiveUI();
                        lastTileHit = null;
                    }
                    else
                    {
                        lastTileHit = hit.collider.gameObject.GetComponent<Tile>();
                        lastTileHit.ActiveUI();
                    }
                }
                else if(hit.collider.CompareTag("TileButton"))
                {
                    Debug.Log("upgrade");
                }
            }
            else
            {
                if (lastTileHit != null)
                {
                    lastTileHit.DeactiveUI();
                    lastTileHit = null;
                }

            }
        }
    }
}
