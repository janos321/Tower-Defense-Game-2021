using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = true;
    private string _gameId;
    //public static string adID;

    [SerializeField] RewardedAdsButton rewardedAdsButton;

    void Start()
    {
        /* MiniIT.Utils.AdvertisingIdFetcher.RequestAdvertisingId(advertisingId =>
 {
     Debug.Log("advertisingId = " + advertisingId);
     adID = advertisingId;
 });*/
        if (!MENUGamobjects.WifiBool)
        {
            return;
        }
        InitializeAds();
    }

    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSGameId                 
            : _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, this);
        OnInitializationComplete();
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        /*if (!MENUGamobjects.WifiBool)
        {
            Instantiate(MENUGamobjects.WifiBlock);
            return;
        }*/
        //Debug.Log(Idek.GetAndroidAdvertiserId());
        rewardedAdsButton.LoadAd();
        
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}