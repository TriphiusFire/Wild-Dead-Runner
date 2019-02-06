using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour
{
    public float speed = 0.3f;

    private Vector2 offset = Vector2.zero;

    private Material mat;
    
    // Start is called before the first frame update
    void Start()
    {
        //get reference to material
        mat = GetComponent<Renderer>().material;
        offset = mat.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        offset.x += speed * Time.deltaTime;
        mat.SetTextureOffset("_MainTex", offset);
    }
}
