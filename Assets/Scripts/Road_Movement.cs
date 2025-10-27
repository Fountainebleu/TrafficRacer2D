using UnityEngine;

public class Road_Movement : MonoBehaviour
{
    public Renderer meshRenderer;
    public float speed = 1f;

    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
    }
}
