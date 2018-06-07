using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 캐릭터 선택 화면을 제어하는 스크립트
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
        haveGold = InputManager.Instance.ReadPlayerGold();
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
        }
        if (0.33f < scrollRect.horizontalNormalizedPosition
            && scrollRect.horizontalNormalizedPosition <= 0.67f)
        {
            DescriptionImage.sprite = DescriptionImage_Orange;
        }
        if (0.67f < scrollRect.horizontalNormalizedPosition
            && scrollRect.horizontalNormalizedPosition <= 1f)
        {
            DescriptionImage.sprite = DescriptionImage_Green;
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

    void OnClickStoreButton()
    {

    }

    void OnClickBattleStartButton()
    {

    }
}
