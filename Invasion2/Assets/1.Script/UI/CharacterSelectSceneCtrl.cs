using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 담당자 : 최대원
/// 캐릭터 선택 화면을 제어하는 스크립트
/// 각각의 동작은 InputManager에게 전달된다.
/// </summary>
public class CharacterSelectSceneCtrl : MonoBehaviour
{
    [SerializeField]
    Sprite DescriptionImage_Red;
    [SerializeField]
    Sprite DescriptionImage_Orange;
    [SerializeField]
    Sprite DescriptionImage_Green;
    [SerializeField]
    ScrollRect scrollRect;
    [SerializeField]
    Image DescriptionImage;
    [SerializeField]
    int haveGold;
    [SerializeField]
    const int haveGoldMax = 999999;
    [SerializeField]
    Text goldText;

   

    private void Update()
    {
        ChangeDescriptionImage();
        ChangeHorizontalNormalizedPosition();
        haveGold = GameMediator.Instance.ReadPlayerGold();
        if (haveGold > haveGoldMax)
        {
            goldText.text = haveGoldMax.ToString("N0") + "+";
        }
        else
        {
            goldText.text = haveGold.ToString("N0");
        }
    }

    void ChangeDescriptionImage()
    {
        if (scrollRect.horizontalNormalizedPosition <= 0.33f)
        {
            DescriptionImage.sprite = DescriptionImage_Red;
            GameMediator.Instance.ChangePlayerType(PlayerType.Sin);
        }
        if (0.33f < scrollRect.horizontalNormalizedPosition
            && scrollRect.horizontalNormalizedPosition <= 0.67f)
        {
            DescriptionImage.sprite = DescriptionImage_Orange;
            GameMediator.Instance.ChangePlayerType(PlayerType.Ho);
        }
        if (0.67f < scrollRect.horizontalNormalizedPosition
            && scrollRect.horizontalNormalizedPosition <= 1f)
        {
            DescriptionImage.sprite = DescriptionImage_Green;
            GameMediator.Instance.ChangePlayerType(PlayerType.Deung);
        }
    }

    void ChangeHorizontalNormalizedPosition()
    {
        if (0f <= scrollRect.horizontalNormalizedPosition
            && scrollRect.horizontalNormalizedPosition < 0.05f)
        {
            scrollRect.horizontalNormalizedPosition = 0f;
            return;
        }
        if (0.48f < scrollRect.horizontalNormalizedPosition
            && scrollRect.horizontalNormalizedPosition < 0.52f)
        {
            scrollRect.horizontalNormalizedPosition = 0.5f;
            return;
        }
        if (0.95f < scrollRect.horizontalNormalizedPosition
            && scrollRect.horizontalNormalizedPosition <= 1f)
        {
            scrollRect.horizontalNormalizedPosition = 1f;
            return;
        }
    }

    public void OnClickStoreButton()
    {
        GameMediator.Instance.ChangeScene(SceneState.Store);
    }

    public void OnClickBattleStartButton()
    {
        GameMediator.Instance.ChangeScene(SceneState.Battle);
    }
}
