using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Unity.IL2CPP;
using BepInEx.Unity.IL2CPP.Utils;
using HarmonyLib;
using UnityEngine;
using UnityEngine.Networking;

namespace TheOtherRoles.Modules;

public class BepInExUpdater : MonoBehaviour
{
    public const string RequiredBepInExVersion = "6.0.0-be.697+53625800b86f6c68751445248260edf0b27a71c2";
    public const string BepInExDownloadURL = "https://builds.bepinex.dev/projects/bepinex_be/697/BepInEx-Unity.IL2CPP-win-x86-6.0.0-be.697%2B5362580.zip";
#if !RELEASE_JL
    public static bool UpdateRequired => Paths.BepInExVersion.ToString() != RequiredBepInExVersion
        && !File.Exists(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "noupdater.txt");
#else
    public static bool UpdateRequired => 
        Int32.Parse(Regex.Match(Paths.BepInExVersion.PreRelease, @"\d+").Value) <
        Int32.Parse(Regex.Match(RequiredBepInExVersion.Substring(6, 12), @"\d+").Value);
#endif

    public void Awake()
    {
        TheOtherRolesPlugin.Logger.LogMessage("BepInEx Update Required...");
        TheOtherRolesPlugin.Logger.LogMessage($"{Paths.BepInExVersion}, {RequiredBepInExVersion} ");
        this.StartCoroutine(CoUpdate());

    }

    [HideFromIl2Cpp]
    public IEnumerator CoUpdate()
    {
        Task.Run(() => MessageBox(GetForegroundWindow(), "Required BepInEx update is downloading, please wait...","The Other Roles", 0));
        UnityWebRequest www = UnityWebRequest.Get(BepInExDownloadURL);
        yield return www.Send();        
        if (www.isNetworkError || www.isHttpError)
        {
            TheOtherRolesPlugin.Logger.LogError(www.error);
            yield break;
        }

        var zipPath = Path.Combine(Paths.GameRootPath, ".bepinex_update");
        File.WriteAllBytes(zipPath, www.downloadHandler.data);

        
        var tempPath = Path.Combine(Path.GetTempPath(), "TheOtherUpdater.exe");
        var asm = Assembly.GetExecutingAssembly();
        var exeName = asm.GetManifestResourceNames().FirstOrDefault(n => n.EndsWith("TheOtherUpdater.exe"));
        
        using(var resource = asm.GetManifestResourceStream(exeName))
        {
            using(var file = new FileStream(tempPath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                resource!.CopyTo(file);
            } 
        }
        
        var startInfo = new ProcessStartInfo(tempPath, $"--game-path \"{Paths.GameRootPath}\" --zip \"{zipPath}\"");
        startInfo.UseShellExecute = false;
        Process.Start(startInfo);
        Application.Quit();
    }

    [DllImport("user32.dll")]
    public static extern IntPtr GetForegroundWindow();
    [DllImport("user32.dll")]
    public static extern int MessageBox(IntPtr hWnd, String text, String caption, int options);
    [DllImport("user32.dll")]
    public static extern int MessageBoxTimeout(IntPtr hwnd, String text, String title, uint type, Int16 wLanguageId, Int32 milliseconds);
}

[HarmonyPatch(typeof(SplashManager), nameof(SplashManager.Update))]
public static class StopLoadingMainMenu
{
    public static bool Prefix()
    {
        return !BepInExUpdater.UpdateRequired;
    }
}