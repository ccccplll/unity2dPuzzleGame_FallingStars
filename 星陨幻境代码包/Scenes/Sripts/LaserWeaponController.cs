using System.Collections;
using UnityEngine;

/// <summary>  
/// ������ƽű��ࡣ  
/// </summary>  
public class LaserWeaponController : MonoBehaviour
{
    public float maxLength = 100;
    public GameObject startVFX;
    public GameObject endVFX;
    public LineRenderer lineRenderer;
    public Vector2 direction; // ���輤�����ҷ���  
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
            Debug.Log("��ײ��λ��Ϊ" + hit.point.ToString());
            length = (hit.point - startPosition).magnitude;
            if(hit.collider.tag == "Player")
            {
                player.GetComponent<PlayerLogic>().dead();
            }
            // ��תĩ��Ч���������Ҫ�Ļ���  
            /*Vector2 toHitPoint = (hit.point - (Vector2)endVFX.transform.position).normalized;
            float angle = Mathf.Atan2(toHitPoint.y, toHitPoint.x) * Mathf.Rad2Deg;
            endVFX.transform.rotation = Quaternion.Euler(0, 0, angle);*/
        }
        else
        {
            Debug.Log("û����ײ");
        }
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, startPosition + direction * length);

        startVFX.transform.position = startPosition;
        endVFX.transform.position = new Vector3(startPosition.x + direction.x * length, startPosition.y + direction.y * length, endVFX.transform.position.z);
        // ע�⣺�������Ǽ��� z ���겻��Ҫ�ı䣬����ֻ�Ǽ򵥵ظ�����ԭʼ z ����  
    }
}