using UnityEngine;
using DG.Tweening;
using UnityEngine.UI; // 버튼 접근용

public class TweenTestUI : MonoBehaviour
{
    public RectTransform panel; // TweenTestPanel
    public Button openButton;   // OpenButton

    void Start()
    {
        // Panel 처음 안 보이게
        panel.localScale = Vector3.zero;

        // 버튼 클릭 이벤트 연결
        openButton.onClick.AddListener(ShowPanel);
    }

    void ShowPanel()
    {
        // 0 → 1로 부드럽게 확대
        panel.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
    }
}
