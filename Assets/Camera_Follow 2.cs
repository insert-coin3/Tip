using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // 추적할 대상 (플레이어)을 인스펙터에서 할당
    public Transform target;
    
    // 카메라 이동의 부드러움을 조절
    public float smoothSpeed = 0.125f; 
    
    // 카메라가 바라볼 목표 위치의 오프셋 (플레이어 위치와의 차이)
    public Vector3 offset; 

    // 모든 물리 업데이트가 끝난 후 카메라 위치를 업데이트 (LateUpdate 사용)
    void LateUpdate()
    {
        if (target == null)
            return;

        // 목표 위치 (플레이어 위치 + 오프셋)
        Vector3 desiredPosition = target.position + offset;
        
        // 현재 카메라 위치에서 목표 위치로 부드럽게 이동합니다.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // 카메라의 위치를 업데이트합니다. (Z축은 건드리지 않음)
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}