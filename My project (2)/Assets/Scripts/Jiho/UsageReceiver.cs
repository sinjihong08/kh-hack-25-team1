using UnityEngine;
using System;
using System.Globalization; // 필요하다면 지역화된 문자열을 처리할 때 사용

// ⚠️ 이 스크립트는 Unity GameObject의 이름과 동일한 
// "UsageReceiver" GameObject에 부착되어 있어야 합니다.
public class UsageReceiver : MonoBehaviour
{
    private const string TAG = "[AndroidUsage]"; // 로그 필터링을 위한 태그
    string usageTimeString;
    // 1. Android (Kotlin)에서 UnitySendMessage를 통해 호출될 함수
    //    호출 형식: UnitySendMessage("UsageReceiver", "ReceiveUsageTime", data)
    public void ReceiveUsageTime()
    {
        Debug.Log(TAG + " Android에서 데이터 수신 성공: " + usageTimeString);

        // 2. 수신된 문자열 데이터를 정수형(분)으로 변환
        if (long.TryParse(usageTimeString, NumberStyles.Integer, CultureInfo.InvariantCulture, out long totalTimeMinutes))
        {
            // 3. 디버그 로그 출력 (최종 확인)
            
            // 시간 및 분으로 변환 (선택 사항)
            long hours = totalTimeMinutes / 60;
            long minutes = totalTimeMinutes % 60;
            
            Debug.Log(TAG + " =======================================");
            Debug.Log(TAG + $" 총 사용 시간 (분): {totalTimeMinutes}분");
            Debug.Log(TAG + $" 총 사용 시간 (시/분): {hours}시간 {minutes}분");
            Debug.Log(TAG + " =======================================");

            // TODO: 여기서 totalTimeMinutes 값을 Unity 내 다른 스크립트나 UI에 전달하여 사용합니다.

        }
        else
        {
            // 데이터 변환 실패 시 로그
            Debug.LogError(TAG + " 수신된 데이터 변환 실패! 문자열: " + usageTimeString);
        }
        
    }
    void Start()
    {
        ReceiveUsageTime();
        Debug.Log(TAG + "sibal");
    }
}