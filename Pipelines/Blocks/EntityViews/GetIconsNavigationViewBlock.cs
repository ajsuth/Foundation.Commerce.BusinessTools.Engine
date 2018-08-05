using Sitecore.Commerce.Core;
using Sitecore.Commerce.EntityViews;
using Sitecore.Framework.Conditions;
using Sitecore.Framework.Pipelines;
using System.Threading.Tasks;

namespace Foundation.Commerce.BusinessTools.Engine.Pipelines.Blocks
{
	public class GetIconsNavigationViewBlock : PipelineBlock<EntityView, EntityView, CommercePipelineExecutionContext>
	{
		public override Task<EntityView> Run(EntityView entityView, CommercePipelineExecutionContext context)
		{
			Condition.Requires(entityView).IsNotNull($"{Name}: The argument cannot be null.");

			foreach (var icon in Constants.IconList)
			{
				var iconDashboardView = new EntityView()
				{
					Name = icon,
					ItemId = icon,
					Icon = icon,
					DisplayRank = 10
				};
				entityView.ChildViews.Add(iconDashboardView);
			}

			return Task.FromResult(entityView);
		}

		public GetIconsNavigationViewBlock() : base(null)
		{
		}
	}
}