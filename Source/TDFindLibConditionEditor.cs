using TD_Find_Lib;
using UnityEngine;
using Verse;

namespace AWATDFindLib
{
    public class TDFindLibConditionEditor : SearchEditorRevertableWindow, ISearchReceiver
    {
        public static readonly string TransferTag = "AWA.TDFindLib";

        public TDFindLibConditionEditor(QuerySearch search) : base(search, TransferTag)
        {
            forcePause = true;
            doCloseX = true;
            absorbInputAroundWindow = true;
            closeOnClickedOutside = true;
            onlyOneOfTypeAllowed = true;
            draggable = false;
            resizeable = false;
        }

        public override Vector2 InitialSize => new(750, 320);

        public override void SetInitialSizeAndPosition()
        {
            base.SetInitialSizeAndPosition();
            windowRect.x = (UI.screenWidth - windowRect.width) / 2;
            windowRect.y = 0;
        }

        public string Source => TransferTag;
        public string ReceiveName => "AWATDFindLib.UseAsAWAPawnCondition".Translate();
        public QuerySearch.CloneArgs CloneArgs => QuerySearch.CloneArgs.use;
        public bool CanReceive() => true;
        public void Receive(QuerySearch search) => Import(search);

        public override void PostOpen()
        {
            base.PostOpen();
            SearchTransfer.Register(this);
        }

        public override void PreClose()
        {
            base.PreClose();
            SearchTransfer.Deregister(this);
        }
    }
}
