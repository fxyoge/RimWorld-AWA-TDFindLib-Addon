using Lomzie.AutomaticWorkAssignment;
using Lomzie.AutomaticWorkAssignment.PawnConditions;
using TD_Find_Lib;
using Verse;

namespace AWATDFindLib
{
    public class TDFindLibPawnCondition : PawnSetting, IPawnCondition
    {
        private QuerySearch _querySearch;

        public QuerySearch QuerySearch => _querySearch;

        public bool HasQuery => _querySearch != null;

        public void OpenOrCreateQuery()
        {
            if (_querySearch == null)
                _querySearch = MakeDefaultQuery();
            Find.WindowStack.Add(new TDFindLibConditionEditor(_querySearch));
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Deep.Look(ref _querySearch, "querySearch");
        }

        public bool IsValid(Pawn pawn, WorkSpecification specification, ResolveWorkRequest request)
        {
            if (_querySearch == null)
                return false;
            return _querySearch.AppliesTo(pawn, pawn.Map);
        }

        private static QuerySearch MakeDefaultQuery()
        {
            QuerySearch search = new();
            search.SetListType(SearchListType.Everyone, false);

            ThingQueryBasicProperty queryColonist = ThingQueryMaker.MakeQuery<ThingQueryBasicProperty>();
            queryColonist.sel = QueryPawnProperty.IsColonist;
            search.Children.Add(queryColonist, remake: false);

            search.name = "AWATDFindLib.DefaultPawnQueryName".Translate();
            return search;
        }
    }
}
