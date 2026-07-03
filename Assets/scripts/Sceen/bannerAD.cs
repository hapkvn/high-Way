using UnityEngine;

public class bannerAD : MonoBehaviour
{
    void Start()
    {
        if(AdManager.instance != null) {
            AdManager.instance.ShowBanner();
        }
    }

    
}
