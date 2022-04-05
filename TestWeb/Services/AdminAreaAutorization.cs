using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;
using System;
using System.Linq;

namespace TestWeb.Services
{
    public class AdminAreaAutorization : IControllerModelConvention
    {
        private readonly string area;
        private readonly string policy;

        public AdminAreaAutorization(string adminArea, string policy)
        {
            this.area = adminArea;
            this.policy = policy;
        }

        public void Apply(ControllerModel controller)
        {
            if (controller.Attributes.Any(atr =>
                        atr is AreaAttribute && (atr as AreaAttribute).RouteValue.Equals(area, StringComparison.OrdinalIgnoreCase))
                || controller.RouteValues.Any(rou =>
                        rou.Key.Equals("area", StringComparison.OrdinalIgnoreCase) && rou.Value.Equals(area, StringComparison.OrdinalIgnoreCase)))
            {
                controller.Filters.Add(new AuthorizeFilter(policy));
            }
        }
    }
}
