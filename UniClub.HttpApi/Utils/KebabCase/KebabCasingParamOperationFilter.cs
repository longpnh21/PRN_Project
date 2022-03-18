using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using UniClub.Helpers;

namespace UniClub.Helper.KebabCase
{
    public class KebabCasingParamOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();
            else
            {
                foreach (var item in operation.Parameters)
                {
                    item.Name = item.Name.FromPascalToKebabCase();
                }
            }
        }
    }
}
