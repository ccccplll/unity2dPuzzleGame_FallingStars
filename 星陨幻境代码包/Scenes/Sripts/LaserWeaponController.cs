using System.Collections;
using UnityEngine;

/// <summary>  
/// 激光控制脚本类。  
/// </summary>  
public class LaserWeaponController : MonoBehaviour
{
    public float maxLength = 100;
    public GameObject startVFX;
    public GameObject endVFX;
    public LineRenderer lineRenderer;
    public Vector2 direction; // 假设激光向右发射  
    public GameObject player;

    private void Start()
    {
        UpdatePosition(startVFX.transform.position,direction);
    }

    private void Update()
    {
        UpdateEndPosition();
    }

    public void UpdatePosition(Vector2 startPosition, Vector2 direction)
    {
        direction = direction.normalized;
        transform.position = startPosition;
        float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }

    private void UpdateEndPosition()
    {
        Vector2 startPosition = startVFX.transform.position;
        RaycastHit2D hit = Physics2D.Raycast(startPosition, direction, maxLength);

        float length = maxLength;

        if (hit.collider != null)
        {
            Debug.Log("碰撞体位置为" + hit.point.ToString());
            length = (hit.point - startPosition).magnitude;
            if(hit.collider.tag == "Player")
            {
                player.GetComponent<PlayerLogic>().dead();
            }
            // 旋转末端效果（如果需要的话）  
            /*Vector2 toHitPoint = (hit.point - (Vector2)endVFX.transform.position).normalized;
            float angle = Mathf.Atan2(toHitPoint.y, toHitPoint.x) * Mathf.Rad2Deg;
            endVFX.transform.rotation = Quaternion.Euler(0, 0, angle);*/
        }
        else
        {
            Debug.Log("没有碰撞");
        }
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, startPosition + direction * length);

        startVFX.transform.position = startPosition;
        endVFX.transform.position = new Vector3(startPosition.x + direction.x * length, startPosition.y + direction.y * length, endVFX.transform.position.z);
        // 注意：这里我们假设 z 坐标不需要改变，或者只是简单地复制了原始 z 坐标  
    }
}