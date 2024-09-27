using YooAsset;

namespace FHFramework
{
    public class InitPackageProcedure : Procedure
    {
        public override void OnEnter()
        {
            LogHelper.Log(LogLevel.Log, "InitPackageProcedure：初始化资源包流程");
        }

        private async void InitPackage()
        {
#if UNITY_EDITOR
            SimulateBuildResult simulateBuildResult = EditorSimulateModeHelper.SimulateBuild(EDefaultBuildPipeline.BuiltinBuildPipeline, "DefaultPackage");
            FileSystemParameters editorFileSystem = FileSystemParameters.CreateDefaultEditorFileSystemParameters(simulateBuildResult);
            EditorSimulateModeParameters initParameters = new();
            initParameters.EditorFileSystemParameters = editorFileSystem;
#else

#endif
        }
    }
}
