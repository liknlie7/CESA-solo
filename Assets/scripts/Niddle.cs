using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Niddle : MonoBehaviour
{

    [SerializeField]
    GameObject needle;

    Rigidbody2D _rigidbody;

    bool is_click = false;
    bool is_speed_up = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
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

        // クリックされた後
        if(is_click)
        {
            if (!is_speed_up)
            {   
                _rigidbody.AddForce(transform.up * 5 ,ForceMode2D.Impulse);

                is_speed_up = true;  
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy1" || col.gameObject.tag == "Enemy2")
        {
            Debug.Log("A");

            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Wall")
        {
            float angle_dir = transform.eulerAngles.z * (Mathf.PI / 180.0f);
            Vector3 dir = new Vector3(Mathf.Cos(angle_dir), Mathf.Sin(angle_dir), 20.0f);
            transform.rotation = Quaternion.Euler(0, 0, -transform.eulerAngles.z);

            //transform.Rotate(dir);
        }
    }
}
