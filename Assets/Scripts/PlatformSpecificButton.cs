using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformSpecificButton : MonoBehaviour
{
    // Trường public để tham chiếu đến button từ Inspector
    public Button LeftButton; 
    public Button RightButton;
    public Button JumpButton;

    void Start()
    {
        // Kiểm tra nền tảng khi bắt đầu
        CheckPlatformAndToggleButton();
    }

    void CheckPlatformAndToggleButton()
    {
        #if UNITY_STANDALONE || UNITY_WEBGL
                // Ẩn button nếu đang chạy trên PC hoặc WebGL
                LeftButton.gameObject.SetActive(false);
                RightButton.gameObject.SetActive(false);
                JumpButton.gameObject.SetActive(false);
        #elif UNITY_ANDROID
                // Hiện button nếu đang chạy trên Android
                LeftButton.gameObject.SetActive(true);
                RightButton.gameObject.SetActive(true);
                JumpButton.gameObject.SetActive(true);
        #endif
    }
}
