using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Niddle_Rotation : MonoBehaviour
{
    public static Vector3 mousePosition;

    [SerializeField]
    GameObject hit_target;

    [SerializeField]
    GameObject root_object;

    bool is_click = false;
    // Start is called before the first frame update
    void Start()
    {
        int count = 0;

        foreach (Transform child in transform)
        {
            count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 回転
        transform.Rotate(new Vector3(0, 0, 2));

        // クリックされたら
        if (Input.GetMouseButtonDown(0))
        {
            var tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var collision2d = Physics2D.OverlapPoint(tapPoint);
            if (collision2d)
            {
                var hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);

                if (hitObject && !is_click)
                {
                    for (int i = 5; i < 10; i++)
                        transform.GetChild(i).gameObject.SetActive(false);
                    
                    root_object.transform.DetachChildren();

                    is_click = true;
                }
            }
        }
    }
}
