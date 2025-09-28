using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [Header("GroundCheck settings")]
    public LayerMask groundLayer;
    public float checkDistance = 0.18f;
    public float horizontalSpread = 0.45f;
    public int rayCount = 3;
    public bool showDebugRays = true;
    public Vector2 originOffset = Vector2.zero;

    public bool IsGrounded { get; private set; }

    private Vector2[] offsets;

    void Awake()
    {
        offsets = new Vector2[rayCount];
        if (rayCount == 1)
        {
            offsets[0] = Vector2.zero;
        }
        else if (rayCount == 3)
        {
            offsets[0] = new Vector2(-horizontalSpread, 0f);
            offsets[1] = Vector2.zero;
            offsets[2] = new Vector2(horizontalSpread, 0f);
        }
        else
        {
            for (int i = 0; i < rayCount; i++)
            {
                float t = (float)i / (rayCount - 1);
                offsets[i] = new Vector2(Mathf.Lerp(-horizontalSpread, horizontalSpread, t), 0f);
            }
        }
    }

    void FixedUpdate()
    {
        CheckGrounded();
    }

    void CheckGrounded()
    {
        IsGrounded = false;
        Vector2 basePos = (Vector2)transform.position + originOffset;

        for (int i = 0; i < offsets.Length; i++)
        {
            Vector2 origin = basePos + offsets[i];
            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, checkDistance, groundLayer);
            if (hit.collider != null)
            {
                IsGrounded = true;
            }

            if (showDebugRays)
            {
                Debug.DrawRay(origin, Vector2.down * checkDistance, hit.collider != null ? Color.green : Color.red);
            }
        }
    }
}
