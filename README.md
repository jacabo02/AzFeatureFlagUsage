# AzFeatureFlagUsage
use feature flag to enable or disable feature that you want from Azure Feature Manager without change your code.

1. On Azure Account create a new feature using Feature Manager --> Add 
2. Then Create an empty project 
3. Add nuget packages 
  Microsoft.Azure.AppConfiguration.AspNetCore
  Microsoft.FeatureManagement.AspNetCore
4. Configure your program.cs
  Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>                
                    webBuilder.ConfigureAppConfiguration(config =>
                    {
                        var settings = config.Build();
                        config.AddAzureAppConfiguration(options =>                        
                        options
                        .Connect({Your Configuration Key Here})
                        .UseFeatureFlags());
                    }).UseStartup<Startup>());
5. Configure your startup.cs
   services.AddFeatureManagement();
6. then create a controller and inject your featuremanager, make it to use feature manager, for my case i have create a feature named Staging and create an enum
      public enum FeatureFlags
    {
        Staging
    }
    
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
  7. create a basic view that uses your controller, and add a link to layout for your new page.  check _Layout.cshtml
  It is taggeg as feature and bind your taghelper by adding  @addTagHelper *, Microsoft.FeatureManagement.AspNetCore to _ViewImports.cshtml
   
  when you run with disabled feature on your azure subscription, you will not see the link you added and when you enable your feature 
  and re-run your project you will see that the feature enabled.
  
  
