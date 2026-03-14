using Lomzie.AutomaticWorkAssignment.UI;
using Verse;

namespace AWATDFindLib
{
    public class Addon_AWATDFindLib : Mod
    {
        public Addon_AWATDFindLib(ModContentPack content) : base(content)
        {
            LongEventHandler.ExecuteWhenFinished(InitializePawnSettingUIHandlers);
        }

        private void InitializePawnSettingUIHandlers()
        {
            PawnSettingUIHandlers.AddHandler(new TDFindLibConditionUIHandler());
        }
    }
}
