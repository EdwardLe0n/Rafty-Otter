using UnityEngine;
using UnityEngine.UI;

public class CharacterGridSize : MonoBehaviour 
{
    private void Update()
    {
        EvaluateCellSize();
        EvaluateHeight();    
    }

    private void EvaluateHeight()
    {
        RectTransform rform = GetComponent<RectTransform>();
        GridLayoutGroup grid = GetComponent<GridLayoutGroup>();

        int childCount = transform.childCount;
        int rowCount = 1 + childCount / 3;

        float height = (grid.cellSize.y * rowCount) + grid.spacing.y * (rowCount - 1) + 4 * grid.padding.top;

        rform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
    }

    private void EvaluateCellSize()
    {
        RectTransform rform = GetComponent<RectTransform>();
        GridLayoutGroup grid = GetComponent<GridLayoutGroup>();

        float cellWidth = transform.parent.GetComponent<RectTransform>().rect.width / 3.5f;
        float cellHeight = transform.parent.GetComponent<RectTransform>().rect.height / 4.5f;
        float spacing = 20 * (cellWidth/cellHeight);

        grid.cellSize = new Vector2(cellWidth, cellHeight);
        grid.spacing = new Vector2(spacing, spacing);
        grid.padding.top = (int)(spacing / 2f);
        grid.padding.bottom = grid.padding.top;
    }
}