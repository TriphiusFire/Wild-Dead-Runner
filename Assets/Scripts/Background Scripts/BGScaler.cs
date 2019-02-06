using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //support multiple screen resolutions for quads (background and ground)
        var height = Camera.main.orthographicSize * 2f;  //y scale of quad
        var width = height * Screen.width / Screen.height;

        if(gameObject.name == "Background")
        {
            transform.localScale = new Vector3(width + 3f, height, 0);
        }
        else
        {
            transform.localScale = new Vector3(width + 3f, 5, 0);
        }

    }

}
