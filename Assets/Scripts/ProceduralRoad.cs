using UnityEngine;

public class ProceduralRoad : MonoBehaviour
{
    void Start()
    {
        int width = 256;
        int height = 256;
        Texture2D texture = new Texture2D(width, height);
        texture.filterMode = FilterMode.Point; 

        Color roadColor = new Color(0.2f, 0.2f, 0.2f); 
        Color lineColor = Color.white;

        Color[] pixels = new Color[width * height];
        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i] = roadColor;
        }

        int laneWidth = 4;
        int dashLength = 30; 
        int gapLength = 30;  

        int lane1X = width / 3;
        int lane2X = (width / 3) * 2;

        for (int y = 0; y < height; y++)
        {
            if ((y % (dashLength + gapLength)) < dashLength)
            {
                for (int x = lane1X; x < lane1X + laneWidth; x++)
                    pixels[y * width + x] = lineColor;

                for (int x = lane2X; x < lane2X + laneWidth; x++)
                    pixels[y * width + x] = lineColor;
            }
        }

        texture.SetPixels(pixels);
        texture.Apply();

        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
        {
            if (rend.material == null || rend.material.name.Contains("Default"))
            {
                rend.material = new Material(Shader.Find("Unlit/Texture"));
            }

            rend.material.mainTexture = texture;

            if (GameManager.Instance != null)
            {
                GameManager.Instance.roadRenderer = rend;
            }
        }
    }
}