using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdManager : MonoBehaviour
{
    private BannerView bannerAd;
    // ads popup
    private InterstitialAd interstitial;
    // ads video for reward
    private RewardedAd rewardBasedVideo;
    bool isRewarded = false;

    public static AdManager instance;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(IntializationStatus=>{ });
        // Get singleton reward based video ads reference
        this.rewardBasedVideo =  new RewardedAd("ca-app-pub-5898061576399296/1775402518");

        // RewardBasedVideoAd is a singleton, so handlers should be registered once
        this.rewardBasedVideo.OnUserEarnedReward  += this.HandleRewardBasedVideoRewarded;
        this.rewardBasedVideo.OnAdClosed += this.HandleRewardBasedVideoClosed;

        this.RequestRewardBasedVideo();

        this.RequestBanner();
    }

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    public void RequestInterstitial()
    {
        string adUnitId = "ca-app-pub-5898061576399296/9358696293";
       
       // Clean up intersitial ad before creating a new one
       if(this.interstitial!=null) this.interstitial.Destroy();
       
       // Create and interstitial
       this.interstitial = new InterstitialAd(adUnitId);

       // Load an interstitial
       this.interstitial.LoadAd(this.CreateAdRequest());
    }

    private void RequestBanner()
    {
        string adUnitId = "ca-app-pub-5898061576399296/9149322043";
        this.bannerAd = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        // AdRequest request = new AdRequest.Builder().Build();
        this.bannerAd.LoadAd(CreateAdRequest());
    }

    public void ShowInterstitial()
    {
        if(this.interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        else
        {
            Debug.Log("Interstitial Ad is not ready yet!");
        }
    }

     public void RequestRewardBasedVideo()
    {
        // string adUnitId = "ca-app-pub-5898061576399296/1775402518";

        this.rewardBasedVideo.LoadAd(this.CreateAdRequest());
    }

    public void ShowRewardBasedVideo()
    {
        if (this.rewardBasedVideo.IsLoaded())
        {
            this.rewardBasedVideo.Show();
        }
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        this.RequestRewardBasedVideo();
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        isRewarded = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (isRewarded)
        {
            isRewarded = false;
            // FindObjectOfType<CharacterSelector>().UnlockRandom();
        }

    }
}
