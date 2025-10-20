using UnityEngine;

// 클래스 이름을 파일 이름과 동일하게 Camera_Follow로 변경합니다.
public class CameraFollow : MonoBehaviour 
{
    // 추적할 대상 (플레이어)을 인스펙터에서 할당
    public Transform target;
    
    // 카메라 이동의 부드러움을 조절
    public float smoothSpeed = 0.125f; 
    
    // 카메라가 바라볼 목표 위치의 오프셋
    public Vector3 offset; 

    // 모든 물리 업데이트가 끝난 후 카메라 위치를 업데이트
    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}