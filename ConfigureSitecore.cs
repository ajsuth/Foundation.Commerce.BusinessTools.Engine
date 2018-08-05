// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureSitecore.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Foundation.Commerce.BusinessTools.Engine
{
	using System.Reflection;
	using Microsoft.Extensions.DependencyInjection;
	using Sitecore.Commerce.Core;
	using Sitecore.Commerce.Plugin.BusinessUsers;
	using Sitecore.Framework.Configuration;
	using Sitecore.Framework.Pipelines.Definitions.Extensions;
	using Sitecore.Framework.Rules;

	/// <summary>
	/// The configure sitecore class.
	/// </summary>
	public class ConfigureSitecore : IConfigureSitecore
	{
		/// <summary>
		/// The configure services.
		/// </summary>
		/// <param name="services">
		/// The services.
		/// </param>
		public void ConfigureServices(IServiceCollection services)
		{
			var assembly = Assembly.GetExecutingAssembly();
			services.RegisterAllPipelineBlocks(assembly);
			services.Sitecore().Rules(config => config.Registry(registry => registry.RegisterAssembly(assembly)));

			services.Sitecore().Pipelines(config => config
				.ConfigurePipeline<IBizFxNavigationPipeline>(pipeline => pipeline
					.Add<Pipelines.Blocks.GetIconsNavigationViewBlock>().After<GetNavigationViewBlock>()
				)
			);

			services.RegisterAllCommands(assembly);
		}
	}
}