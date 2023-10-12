using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.iOS;
using UnityEngine;

public class IOSNotifications : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RequestAuthorization());
    }

    IEnumerator RequestAuthorization()
    {
        var authorizationOption = Unity.Notifications.iOS.AuthorizationOption.Alert | AuthorizationOption.Badge;
        using (var req = new AuthorizationRequest(authorizationOption, true))
        {
            while (!req.IsFinished)
            {
                yield return null;
            };

            string res = "\n RequestAuthorization:";
            res += "\n finished: " + req.IsFinished;
            res += "\n granted :  " + req.Granted;
            res += "\n error:  " + req.Error;
            res += "\n deviceToken:  " + req.DeviceToken;
            Debug.Log(res);
        }
    }
}
