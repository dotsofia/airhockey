using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb2d;

    [SerializeField]
    float yBound = 3.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var pos = transform.position;
        pos.x = mousePos.x;
        pos.y = mousePos.y;

        if (pos.y > -0.5) {
            pos.y = -0.5f;
        } else if (pos.y < -3.35) {
            pos.y = -3.35f;
        }

        if (pos.x > 1.86)
        {
            pos.x = 1.86f;
        }
        else if (pos.x < -1.86) { 
            pos.x = -1.86f; 
        }
        transform.position = pos;
    }
}
