using System;
using System.Collections.Generic;
using HarmonyLib;
using BepInEx;
using UnityEngine;
using System.Reflection;
using UnityEngine.XR;
using Photon.Pun;
using UnityEngine.UI;
using System.IO;
using System.Net;
using Photon.Realtime;
using UnityEngine.Rendering;

namespace NoTagLag
{
    [BepInPlugin("org.kokuchi.monkeytag.notaglag", "BE GONE TAGLAG!", "1.0.0")]
    public class MyMenuPatcher : BaseUnityPlugin
    {
        public void Awake()
        {
            var harmony = new Harmony("com.kokuchi.monkeytag.notaglag");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(GorillaLocomotion.Player))]
    [HarmonyPatch("Update", MethodType.Normal)]
    public class Class1
    {
        static void Postfix(GorillaLocomotion.Player __instance)
        {
            {
                if (!PhotonNetwork.CurrentRoom.IsVisible || !PhotonNetwork.InRoom)
                {
                    List<InputDevice> list = new List<InputDevice>();
                    InputDevices.GetDevicesWithCharacteristics(UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Left | UnityEngine.XR.InputDeviceCharacteristics.Controller, list);
                    
                    // TAG LAG MOVEMENT \\
                    __instance.disableMovement = false;
                }
            }
        }
    }
}

// MADE BY KOKUCHI \\