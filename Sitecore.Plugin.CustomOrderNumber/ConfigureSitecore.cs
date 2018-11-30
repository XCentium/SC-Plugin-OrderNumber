using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Orders;
using Sitecore.Framework.Configuration;
using Sitecore.Framework.Pipelines.Definitions.Extensions;
using Sitecore.Plugin.CustomOrderNumber.Pipelines.Blocks;

namespace Sitecore.Plugin.CustomOrderNumber
{
    public class ConfigureSitecore : IConfigureSitecore
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.RegisterAllPipelineBlocks(assembly);

            services.Sitecore().Pipelines(config => config

                .ConfigurePipeline<IOrderPlacedPipeline>(builder => builder.Replace<OrderPlacedAssignConfirmationIdBlock, CustomOrderNumberBlock>())
            );

            services.RegisterAllCommands(assembly);
        }
    }
}
