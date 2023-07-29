using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityLevelPlay : MonoBehaviour 
{   
    private bool AdsBoolPoint;
    private bool AdsBoolIncerauseLuck;

    [Header("Add Point - (Reward Video)")]
    public Animation AnimationText;
    public int yes;

    [Header("Increasing Luck - (Reward Video)")]
    public Animator BonusAnimator;
    public Text BonusText;
    public int BonusIncerauseLuck;

    [Header("Ads buttons")]
    public Button Button_IncerauseLuck;
    public Button Button_AddOnePoint;

    private void Start ()
    {
        IronSource.Agent.init ("1ac5ea725");
        IronSource.Agent.validateIntegration();

        LoadBanner();
    }

    private void OnEnable ()
    {
        IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitializationCompletedEvent;

        //Add AdInfo Banner Events
        IronSourceBannerEvents.onAdLoadedEvent += BannerOnAdLoadedEvent;
        IronSourceBannerEvents.onAdLoadFailedEvent += BannerOnAdLoadFailedEvent;
        IronSourceBannerEvents.onAdClickedEvent += BannerOnAdClickedEvent;
        IronSourceBannerEvents.onAdScreenPresentedEvent += BannerOnAdScreenPresentedEvent;
        IronSourceBannerEvents.onAdScreenDismissedEvent += BannerOnAdScreenDismissedEvent;
        IronSourceBannerEvents.onAdLeftApplicationEvent += BannerOnAdLeftApplicationEvent;

        //Add AdInfo Rewarded Video Events
        IronSourceRewardedVideoEvents.onAdOpenedEvent += RewardedVideoOnAdOpenedEvent;
        IronSourceRewardedVideoEvents.onAdClosedEvent += RewardedVideoOnAdClosedEvent;
        IronSourceRewardedVideoEvents.onAdAvailableEvent += RewardedVideoOnAdAvailable;
        IronSourceRewardedVideoEvents.onAdUnavailableEvent += RewardedVideoOnAdUnavailable;
        IronSourceRewardedVideoEvents.onAdShowFailedEvent += RewardedVideoOnAdShowFailedEvent;
        IronSourceRewardedVideoEvents.onAdRewardedEvent += RewardedVideoOnAdRewardedEvent;
        IronSourceRewardedVideoEvents.onAdClickedEvent += RewardedVideoOnAdClickedEvent;

    }

    void OnApplicationPause(bool isPaused) 
    {                 
        IronSource.Agent.onApplicationPause(isPaused);
    }

    private void SdkInitializationCompletedEvent()  { }

    /************* Banner *************/

    public void LoadBanner ()
    {
        IronSource.Agent.loadBanner(IronSourceBannerSize.BANNER, IronSourceBannerPosition.BOTTOM);
    }

    void BannerOnAdLoadedEvent(IronSourceAdInfo adInfo){
    }
    void BannerOnAdLoadFailedEvent(IronSourceError ironSourceError){
    }
    void BannerOnAdClickedEvent(IronSourceAdInfo adInfo){
    }
    void BannerOnAdScreenPresentedEvent(IronSourceAdInfo adInfo){
    }
    void BannerOnAdScreenDismissedEvent(IronSourceAdInfo adInfo){
    }
    void BannerOnAdLeftApplicationEvent(IronSourceAdInfo adInfo){
    }

    /************* Reward *************/

    public void Ads_IncerauseLuck ()
    {
        if (IronSource.Agent.isRewardedVideoAvailable())
        {
            AdsBoolIncerauseLuck = true;
            IronSource.Agent.showRewardedVideo();
        }

        else

        Debug.Log("Reward Video Not Work");
    }

    public void Ads_AddPoint ()
    {
        if (IronSource.Agent.isRewardedVideoAvailable())
        {
            AdsBoolPoint = true;
            IronSource.Agent.showRewardedVideo();
        }

        else

        Debug.Log("Reward Video Not Work");
    }

    void RewardedVideoOnAdAvailable(IronSourceAdInfo adInfo){
    }
    void RewardedVideoOnAdUnavailable() {
    }
    void RewardedVideoOnAdOpenedEvent(IronSourceAdInfo adInfo){
    }
    void RewardedVideoOnAdClosedEvent(IronSourceAdInfo adInfo){
    }
    void RewardedVideoOnAdShowFailedEvent(IronSourceError error, IronSourceAdInfo adInfo){
    }
    void RewardedVideoOnAdClickedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo){
    }

    void RewardedVideoOnAdRewardedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo)
    {   
        if (AdsBoolPoint == true)
        {
            // Add point
            yes += 1;
            AnimationText.Play();
            PlayerPrefs.SetInt ("yes", yes);

            AdsBoolPoint = false;
        }

        if (AdsBoolIncerauseLuck == true)
        {
            // Incerause Luck
            BonusIncerauseLuck = 1;
            PlayerPrefs.SetInt ("BonusIncerauseLuck", BonusIncerauseLuck);

            StartCoroutine(EnableBonus_IncerauseLuck());
            BonusAnimator.GetComponent<Animator>().enabled = true;
            Button_IncerauseLuck.interactable = false;
            AdsBoolIncerauseLuck = false;
        }
    }

    IEnumerator EnableBonus_IncerauseLuck()
    {
        yield return new WaitForSeconds(60);

        BonusAnimator.GetComponent<Animator>().enabled = false;
        Button_IncerauseLuck.interactable = true;
        BonusText.color = Color.white;

        BonusIncerauseLuck = 0;
        PlayerPrefs.SetInt ("BonusIncerauseLuck", BonusIncerauseLuck);
    }
}