#if XR_MGMT_GTE_320

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using UnityEngine;
using UnityEngine.XR.WindowsMR;

using UnityEditor;
using UnityEditor.XR.Management;
using UnityEditor.XR.Management.Metadata;

namespace UnityEditor.XR.WindowsMR
{
    class XRPackage : IXRPackage
    {
        private class WMRLoaderMetadata : IXRLoaderMetadata
        {
            public string loaderName { get; set; }
            public string loaderType { get; set; }
            public List<BuildTargetGroup> supportedBuildTargets { get; set; }
        }

        private class WMRPackageMetadata : IXRPackageMetadata
        {
            public string packageName { get; set; }
            public string packageId { get; set; }
            public string settingsType { get; set; }
            public List<IXRLoaderMetadata> loaderMetadata { get; set; } 
        }
        
        private static IXRPackageMetadata s_Metadata = new WMRPackageMetadata(){
                packageName = "Windows XR Plugin",
                packageId = "com.unity.xr.windowsmr",
                settingsType = "UnityEditor.XR.WindowsMR.WindowsMRPackageSettings",
                loaderMetadata = new List<IXRLoaderMetadata>() {
                new WMRLoaderMetadata() {
                        loaderName = "Windows Mixed Reality",
                        loaderType = "UnityEngine.XR.WindowsMR.WindowsMRLoader",
                        supportedBuildTargets = new List<BuildTargetGroup>() {
                            BuildTargetGroup.Standalone,
                            BuildTargetGroup.WSA
                        }
                    },
                }
            };

        public IXRPackageMetadata metadata => s_Metadata;

        public bool PopulateNewSettingsInstance(ScriptableObject obj)
        {
            WindowsMRPackageSettings packageSettings = obj as WindowsMRPackageSettings;
            if (packageSettings != null)
            {
                var settings = packageSettings.GetSettingsForBuildTargetGroup(BuildTargetGroup.WSA);
                if (settings != null)
                {
                    switch (PlayerSettings.VRWindowsMixedReality.depthBufferFormat)
                    {
                    case PlayerSettings.VRWindowsMixedReality.DepthBufferFormat.DepthBufferFormat16Bit:
                        settings.DepthBufferFormat = WindowsMRSettings.DepthBufferOption.DepthBuffer16Bit;
                        break;
                    case PlayerSettings.VRWindowsMixedReality.DepthBufferFormat.DepthBufferFormat24Bit:
                        settings.DepthBufferFormat = WindowsMRSettings.DepthBufferOption.DepthBuffer24Bit;
                        break;
                    }

                    settings.UseSharedDepthBuffer = PlayerSettings.VRWindowsMixedReality.depthBufferSharingEnabled;
                    return true;
                }
            }
            return false;

        }
    }
}

#endif //XR_MGMT_GTE_320
