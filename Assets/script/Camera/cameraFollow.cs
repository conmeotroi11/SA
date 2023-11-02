using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public List<Transform> targets; // Danh sách các players bạn muốn theo dõi
    public float smooth = 0.1f; // Tốc độ di chuyển mượt mà của camera

    private Vector3 velocity;

    void LateUpdate()
    {
        if (targets.Count == 0)
        {
            return;
        }

        // Tính toán vị trí trung bình của tất cả các players
        Vector3 averagePosition = Vector3.zero;
        foreach (Transform target in targets)
        {
            averagePosition += target.position;
        }
     

        // Cập nhật vị trí camera với các giá trị mới sử dụng SmoothDamp
        Vector3 desiredPosition = averagePosition;
        desiredPosition.y = transform.position.y;
        desiredPosition.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smooth);
    }
}