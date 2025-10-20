using UnityEngine;
using Unity.Netcode; // Netcode 네임스페이스 추가

public class TestNetworkStarter : MonoBehaviour
{
    void Start()
    {
        // Unity 에디터에서 실행될 경우
        #if UNITY_EDITOR
        
        // NetworkManager 컴포넌트를 찾습니다.
        NetworkManager netManager = GetComponent<NetworkManager>();

        if (netManager != null)
        {
            // 자동으로 Host(서버 겸 클라이언트)로 시작합니다.
            netManager.StartHost();
            
            // 이 스크립트는 임시 테스트용이므로,
            // 나중에 UI 버튼을 구현할 때는 삭제하거나 비활성화해야 합니다.
        }

        #endif
    }
}