using UnityEngine;
using GoogleMobileAds.Api; 
using System;

public class AdManager : MonoBehaviour
{
    public static AdManager instance;

    private string bannerId = "ca-app-pub-3825622194921423/8296256554";
    private string interstitialId = "ca-app-pub-3825622194921423/6079754389";
    private string rewardedId = "ca-app-pub-3825622194921423/3773155249";

    private BannerView bannerView;
    private InterstitialAd interstitialAd;
    private RewardedAd rewardedAd;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Screen.fullScreen = false;

            MobileAds.Initialize(initStatus => { });
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ShowBanner();
        LoadInterstitial();
        LoadRewarded();
    }

    public void ShowBanner()
    {
        if (bannerView != null) bannerView.Destroy();
        
        bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.Top);
        AdRequest request = new AdRequest();
        bannerView.LoadAd(request);
    }
    
    public void HideBanner()
    {
        if (bannerView != null) bannerView.Destroy();
    }

    public void LoadInterstitial()
    {
        if (interstitialAd != null) interstitialAd.Destroy();
        
        AdRequest request = new AdRequest();
        InterstitialAd.Load(interstitialId, request, (InterstitialAd ad, LoadAdError error) =>
        {
            if (error == null) interstitialAd = ad;
        });
    }

    public void ShowInterstitial()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            interstitialAd.Show();
            LoadInterstitial(); 
        }
    }

    public void LoadRewarded()
    {
        if (rewardedAd != null) rewardedAd.Destroy();

        AdRequest request = new AdRequest();
        RewardedAd.Load(rewardedId, request, (RewardedAd ad, LoadAdError error) =>
        {
            if (error == null) rewardedAd = ad;
        });
    }
    
    public void ShowRewarded(Action onRewardEarned)
    {
        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) =>
            {
                onRewardEarned?.Invoke();
            });
            LoadRewarded();
        }
        else
        {
            Debug.Log("Video chưa tải xong, yêu cầu kiểm tra lại mạng!");
        }
    }
}