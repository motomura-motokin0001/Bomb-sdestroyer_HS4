using UnityEngine;

[ExecuteInEditMode]
public class GridLayout3D : MonoBehaviour
{
    public int rows = 10;
    public int columns = 10;
    public float spacing = 2.0f;
    public int height = 5;

    void Update()
    {
        ArrangeChildren();
    }

    void ArrangeChildren()
    {
        int index = 0;
        foreach (Transform child in transform)
        {
            int x = index % columns;
            int z = (index / columns) % rows;
            int y = index / (columns * rows);
            
            if(y >= height) break;

            child.localPosition = new Vector3(x * spacing , y * spacing ,z * spacing);
            index++;
        }
    }
}
