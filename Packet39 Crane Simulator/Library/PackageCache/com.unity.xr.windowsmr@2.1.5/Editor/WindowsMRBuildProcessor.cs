using System;
using System.Collections.Generic;
using System.IO;

using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.XR.Management;

using UnityEngine;
using UnityEngine.XR.Management;

using UnityEngine.XR.WindowsMR;

namespace UnityEditor.XR.WindowsMR
{
    /// <summary>Build Processor class used to handle XR Plugin specific build actions/</summary>
    /// <typeparam name="WindowsMRSettings">The settings instance type the build processor will use.</typeparam>
    public class WindowsMRBuildProcessor : XRBuildHelper<WindowsMRSettings>
    {
        public override string BuildSettingsKey { get { return Constants.k_SettingsKey; } }

        private WindowsMRPackageSettings PackageSettingsForBuildTargetGroup(BuildTargetGroup buildTargetGroup)
        {
            UnityEngine.Object settingsObj = null;
            EditorBuildSettings.TryGetConfigObject(BuildSettingsKey, out settingsObj);
            WindowsMRPackageSettings settings = settingsObj as WindowsMRPackageSettings;

            if (settings == null)
            {
                var assets = AssetDatabase.FindAssets("t:WindowsMRPackageSettings");
                if (assets.Length == 1)
                {
                    string path = AssetDatabase.GUIDToAssetPath(assets[0]);
                    settings = AssetDatabase.LoadAssetAtPath(path, typeof(WindowsMRPackageSettings)) as WindowsMRPackageSettings;
                    if (settings != null)
                    {
                        EditorBuildSettings.AddConfigObject(BuildSettingsKey, settings, true);
                    }

                }
            }

            return settings;
        }

        /// <summary>Get the XR Plugin build settings for the specific build platform.</summary>
        /// <param name="buildTargetGroup">The build platform we want to get settings for.</param>
        /// <returns>An instance of WindowsMRBuildSettings, or null if there are none for the current build platform.</returns>
        public WindowsMRBuildSettings BuildSettingsForBuildTargetGroup(BuildTargetGroup buildTargetGroup)
        {
            WindowsMRPackageSettings settings = PackageSettingsForBuildTargetGroup(buildTargetGroup);

            if (settings != null)
            {
                WindowsMRBuildSettings targetSettings = settings.GetBuildSettingsForBuildTargetGroup(buildTargetGroup);
                return targetSettings;
            }

            return null;
        }

        /// <summary>Get a generic object reference for runtime settings for the build platform</summary>
        /// <param name="buildTargetGroup">The build platform we want to get settings for.</param>
        /// <returns>An object instance of the saved settings, or null if there are none.</returns>
        public override UnityEngine.Object SettingsForBuildTargetGroup(BuildTargetGroup buildTargetGroup)
        {
            WindowsMRPackageSettings settings = PackageSettingsForBuildTargetGroup(buildTargetGroup);

            if (settings != null)
            {
                WindowsMRSettings targetSettings = settings.GetSettingsForBuildTargetGroup(buildTargetGroup);
                return targetSettings;
            }

            return null;
        }

        const string k_ForcePrimaryWindowHolographic = "force-primary-window-holographic";

        /// <summary>OnPostprocessBuild override to provide XR Plugin specific build actions.</summary>
        /// <param name="report">The build report.</param>
        public override void OnPostprocessBuild(BuildReport report)
        {
            base.OnPostprocessBuild(report);

            XRGeneralSettings settings = XRGeneralSettingsPerBuildTarget.XRGeneralSettingsForBuildTarget(report.summary.platformGroup);
            if (settings == null)
                return;

            bool loaderFound = false;
            for (int i = 0; i < settings.Manager.loaders.Count; ++i)
            {
                if (settings.Manager.loaders[i] as WindowsMRLoader != null)
                {
                    loaderFound = true;
                    break;
                }
            }

            if (!loaderFound)
                return;

            string bootConfigPath = report.summary.outputPath;

            if (report.summary.platformGroup == BuildTargetGroup.WSA)
            {
                bool usePrimaryWindow = true;
                WindowsMRBuildSettings buildSettings = BuildSettingsForBuildTargetGroup(report.summary.platformGroup);
                if (buildSettings != null)
                {
                    usePrimaryWindow = buildSettings.UsePrimaryWindowForDisplay;
                }

                // Boot Config data path is highly specific to the platform being built.
                bootConfigPath = Path.Combine(bootConfigPath, PlayerSettings.productName);
                bootConfigPath = Path.Combine(bootConfigPath, "Data");
                bootConfigPath = Path.Combine(bootConfigPath, "boot.config");

                using (StreamWriter sw = File.AppendText(bootConfigPath))
                {
                    sw.WriteLine(String.Format("{0}={1}", k_ForcePrimaryWindowHolographic, usePrimaryWindow ? 1 : 0));
                }
            }
        }

        private readonly string[] nativePluginNames = new string[]
        {
            "Microsoft.Holographic.AppRemoting.dll",
            "PerceptionDevice.dll",
            "UnityRemotingWMR.dll"
        };

        public bool ShouldIncludeRemotingPluginsInBuild(string path)
        {
            XRGeneralSettings generalSettings = XRGeneralSettingsPerBuildTarget.XRGeneralSettingsForBuildTarget(BuildPipeline.GetBuildTargetGroup(EditorUserBuildSettings.activeBuildTarget));
            if (generalSettings == null)
                return false;

            bool loaderFound = false;
            for (int i = 0; i < generalSettings.Manager.loaders.Count; ++i)
            {
                if (generalSettings.Manager.loaders[i] as WindowsMRLoader != null)
                {
                    loaderFound = true;
                    break;
                }
            }

            if (!loaderFound)
                return false;

            WindowsMRBuildSettings buildSettings = BuildSettingsForBuildTargetGroup(BuildPipeline.GetBuildTargetGroup(EditorUserBuildSettings.activeBuildTarget)) as WindowsMRBuildSettings;
            if (buildSettings == null)
                return false;

            return buildSettings.HolographicRemoting;
        }

        /// <summary>OnPreprocessBuild override to provide XR Plugin specific build actions.</summary>
        /// <param name="report">The build report.</param>
        public override void OnPreprocessBuild(BuildReport report)
        {
            base.OnPreprocessBuild(report);

            var allPlugins = PluginImporter.GetAllImporters();
            foreach (var plugin in allPlugins)
            {
                if (plugin.isNativePlugin)
                {
                    foreach (var pluginName in nativePluginNames)
                    {
                        if (plugin.assetPath.Contains(pluginName))
                        {
                            plugin.SetIncludeInBuildDelegate(ShouldIncludeRemotingPluginsInBuild);
                            break;
                        }
                    }
                }
            }
        }
    }
}
