using UnityEditor;

public class SettingsMenu
{
    [MenuItem("FHFramework/FHFrameworkSettings")]
    public static void OpenSettings()
    {
        SettingsService.OpenProjectSettings("FHFramework/FHFrameworkSettings");
    }
}
