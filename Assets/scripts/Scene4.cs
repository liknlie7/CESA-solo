using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene4 : MonoBehaviour
{

    bool is_click;
    // Start is called before the first frame update
    void Start()
    {
        is_click = false;
    }

    // Update is called once per frame
    void Update()
    {
        // クリックされたら
        if (Input.GetMouseButtonDown(0))
        {
            var tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var collision2d = Physics2D.OverlapPoint(tapPoint);
            {
                if (collision2d)
                {
                    var hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);

                    if (hitObject)
                    {
                        is_click = true;
                    }
                }
            }
        }

        if(is_click)
        {
            SceneManager.LoadScene("Stage_1");
        }
    }
}
