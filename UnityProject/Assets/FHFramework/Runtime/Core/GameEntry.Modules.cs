namespace FHFramework
{
    public partial class GameEntry
    {
        public static ResourceModule Resource { get; private set; }
        public static FsmModule Fsm { get; private set; }
        public static ProcedureModule Procedure { get; private set; }

        private void InitModules()
        {
            Resource = GetComponentInChildren<ResourceModule>();
            Fsm = GetComponentInChildren<FsmModule>();
            Procedure = GetComponentInChildren<ProcedureModule>();
        }
    }
}