using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;
using System;
using System.Linq;

namespace TestWeb.Services
{
    public class AdminAreaAutorization : IControllerModelConvention
    {
        private readonly string _area;
        private readonly string _policy;

        public AdminAreaAutorization(string adminArea, string policy)
        {
            _area = adminArea;
            _policy = policy;
        }

        public void Apply(ControllerModel controller)
        {
            if (controller.Attributes.Any(atr =>
                        atr is AreaAttribute && (atr as AreaAttribute).RouteValue.Equals(_area, StringComparison.OrdinalIgnoreCase))
                || controller.RouteValues.Any(rou =>
                        rou.Key.Equals("_area", StringComparison.OrdinalIgnoreCase) && rou.Value.Equals(_area, StringComparison.OrdinalIgnoreCase)))
            {
                controller.Filters.Add(new AuthorizeFilter(_policy));
            }
        }
    }
}
