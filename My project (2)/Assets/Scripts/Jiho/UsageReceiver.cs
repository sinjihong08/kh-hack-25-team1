using UnityEngine;
using System;

public class UsageReceiver : MonoBehaviour
{
    // Android에서 UnitySendMessage를 통해 호출될 함수
    // GameObject 이름: "UsageReceiver"
    // 함수 이름: "ReceiveUsageTime"
    public void ReceiveUsageTime(string usageTimeString)
    {
        Debug.Log("Android에서 사용 시간 데이터 수신: " + usageTimeString);

        try
        {
            // 수신된 문자열을 정수(분)로 변환
            if (int.TryParse(usageTimeString, out int totalTimeMinutes))
            {
                // ✨ 측정된 사용 시간(분)을 Unity에서 사용합니다.
                Debug.Log($"총 휴대폰 사용 시간: {totalTimeMinutes}분");

                // 예시: UI 텍스트 업데이트
                // GameObject.Find("TimeDisplay").GetComponent<TMPro.TextMeshProUGUI>().text = 
                //     $"총 사용 시간: {totalTimeMinutes}분";
            }
            else
            {
                Debug.LogError("수신된 데이터가 유효한 숫자가 아닙니다: " + usageTimeString);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("사용 시간 처리 중 오류 발생: " + e.Message);
        }
    }
}