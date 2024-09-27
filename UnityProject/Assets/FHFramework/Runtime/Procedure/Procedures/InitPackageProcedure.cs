using YooAsset;

namespace FHFramework
{
    public class InitPackageProcedure : Procedure
    {
        public override void OnEnter()
        {
            LogHelper.Log(LogLevel.Log, "InitPackageProcedure����ʼ����Դ������");
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
