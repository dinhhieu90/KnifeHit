using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class GoogleAdMobController : MonoBehaviour
{

    public static GoogleAdMobController Instance;
    private BannerView bannerView;
    private InterstitialAd interstitialAd;
    private RewardedAd rewardedAd;

    public UnityEvent OnAdLoadedEvent;
    public UnityEvent OnAdFailedToLoadEvent;
    public UnityEvent OnAdOpeningEvent;
    public UnityEvent OnAdFailedToShowEvent;
    public UnityEvent OnUserEarnedRewardEvent;
    public UnityEvent OnAdClosedEvent;
    public string appI= "ca-app-pub-5011614185348908~8183843244";


    #region UNITY MONOBEHAVIOR METHODS

    public void Start()
    {
     
        MobileAds.Initialize(HandleInitCompleteAction);
    }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
   
    private void HandleInitCompleteAction(InitializationStatus initstatus)
    {
       
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            RequestBannerAd();

        });
    }


    #endregion
    #region HELPER METHODS
    private AdRequest CreateAdRequest()
    {
       
        
        return new AdRequest.Builder().Build();
    }

    #endregion

    #region BANNER ADS

    public void RequestBannerAd()
    {
           string adUnitId = "ca-app-pub-5011614185348908/8143442653";
       
        // These ad units are configured to always serve test ads.


        // Clean up banner before reusing
        if (bannerView != null)
        {
            bannerView.Destroy();
        }

        // Create a banner at bottom of the screen
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        // Add Event Handlers
        bannerView.OnAdLoaded += (sender, args) => OnAdLoadedEvent.Invoke();
        bannerView.OnAdFailedToLoad += (sender, args) => OnAdFailedToLoadEvent.Invoke();
        bannerView.OnAdOpening += (sender, args) => OnAdOpeningEvent.Invoke();
        bannerView.OnAdClosed += (sender, args) => OnAdClosedEvent.Invoke();

        // Load a banner ad
        bannerView.LoadAd(CreateAdRequest());
    }

    public void DestroyBannerAd()
    {

        bannerView.Destroy();

    }


    #endregion

    #region INTERSTITIAL ADS
    public void RequestAndLoadInterstitialAd()
    {
        //  statusText.text = "Requesting Interstitial Ad.";


           string adUnitId = "ca-app-pub-5011614185348908/9264952636";
    //    string adUnitId = "";
        // Clean up interstitial before using it
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
        }
        interstitialAd = new InterstitialAd(adUnitId);

        // Add Event Handlers
        interstitialAd.OnAdLoaded += (sender, args) => OnAdLoadedEvent.Invoke();
         interstitialAd.OnAdFailedToLoad += (sender, args) =>
        {
            MobileAdsEventExecutor.ExecuteInUpdate(() =>
            {

                GamePlay.Instance.RestartGameAfterCheckAds();
            });
        };

        interstitialAd.OnAdClosed += (sender, args) =>
        {
            MobileAdsEventExecutor.ExecuteInUpdate(() =>
            {

                GamePlay.Instance.RestartGameAfterCheckAds();
            });
        };

        // Load an interstitial ad
        interstitialAd.LoadAd(CreateAdRequest());
    }

    public void ShowInterstitialAd()
    {
        if (interstitialAd != null && interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
        else
        {
            GamePlay.Instance.RestartGameAfterCheckAds();
        }

    }

    public void DestroyInterstitialAd()
    {
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
        }
    }

    #endregion


    #region REWARDED ADS
    public void RequestAndLoadRewardedAd()
    {

           string adUnitId = "ca-app-pub-5011614185348908/1132980049";
    //    string adUnitId = "";
           // create new rewarded ad instance
           rewardedAd = new RewardedAd(adUnitId);

        // Add Event Handlers
        rewardedAd.OnAdLoaded += (sender, args) => OnAdLoadedEvent.Invoke();
        rewardedAd.OnAdFailedToLoad += (sender, args) =>
        {
            MobileAdsEventExecutor.ExecuteInUpdate(() =>
            {

                GamePlay.Instance.ContinuePlayAfterAds();
            });
        };
        rewardedAd.OnAdOpening += (sender, args) => OnAdOpeningEvent.Invoke();
        rewardedAd.OnAdFailedToShow += (sender, args) =>
        {
            MobileAdsEventExecutor.ExecuteInUpdate(() =>
            {

                GamePlay.Instance.ContinuePlayAfterAds();
            });
        };
        rewardedAd.OnAdClosed += (sender, args) => OnAdClosedEvent.Invoke();
        rewardedAd.OnUserEarnedReward += (sender, args) =>
        {
            MobileAdsEventExecutor.ExecuteInUpdate(() =>
            {

                GamePlay.Instance.ContinuePlayAfterAds();
            });
        };

        // Create empty ad request
        rewardedAd.LoadAd(CreateAdRequest());
    }

    public void ShowRewardedAd()
    {
        if (rewardedAd != null)
        {
            rewardedAd.Show();
        }

    }
    #endregion

}
