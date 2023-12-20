using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Ump.Api;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RequestConsenForm();
    }

    private void RequestConsenForm()
    {
        ConsentRequestParameters request = new ConsentRequestParameters
        {
            TagForUnderAgeOfConsent = false
        };
        ConsentInformation.Update(request, OnConsentInfoUpdated);
    }

    private void OnConsentInfoUpdated(FormError consentError)
    {
        if (consentError != null)
        {
            Debug.Log("ConsentInfoUpdate Error: " + consentError);
            return;
        }

        ConsentForm.LoadAndShowConsentFormIfRequired((FormError formError) =>
        {
            if (formError != null)
            {
                Debug.Log("Consent form error: " + formError);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
