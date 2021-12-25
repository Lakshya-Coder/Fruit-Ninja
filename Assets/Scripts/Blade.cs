using UnityEngine;

public class Blade : MonoBehaviour
{
    public float minVelo = 0.1f;
    private Rigidbody2D rb;
    private Vector3 lasteMousePos;
    private Vector3 mouseVelo;
    private CircleCollider2D collider;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
    }

    void FixedUpdate()
    {
        collider.enabled = IsMouseMoving();
        SetBladeToMouse();
    }

    private void SetBladeToMouse()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10;
        rb.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private bool IsMouseMoving()
    {
        var curMousePos = transform.position;
        float travel = (lasteMousePos - curMousePos).magnitude;
        lasteMousePos = curMousePos;

        if (travel > minVelo) return true;
        return false;
    }

}
