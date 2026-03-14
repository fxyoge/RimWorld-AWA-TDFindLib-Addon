using Lomzie.AutomaticWorkAssignment.UI;
using UnityEngine;
using Verse;

namespace AWATDFindLib
{
    public class TDFindLibConditionUIHandler : PawnSettingUIHandler<TDFindLibPawnCondition>
    {
        private const float ButtonHeight = 32f;

        protected override float Handle(Vector2 position, float width, TDFindLibPawnCondition condition)
        {
            string label = condition.HasQuery
                ? condition.QuerySearch.name
                : "AWATDFindLib.EditQuery".Translate();

            Rect buttonRect = new(position, new Vector2(width, ButtonHeight));
            if (Widgets.ButtonText(buttonRect, label))
                condition.OpenOrCreateQuery();

            return ButtonHeight;
        }
    }
}
