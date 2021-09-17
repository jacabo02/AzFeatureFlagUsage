using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzFeatureFlagUsage.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IFeatureManager _featureManager;

        public FeatureController(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }

        [FeatureGate(FeatureFlags.Staging)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
