using AutoMapper;
using SuperLoja.Api.Presentation.Profiles;

public class PresentationProfileTests
{
    [Fact(DisplayName = "Profile do AutoMapper ViewModelsProfile deve ser valido")]
    public void MappingProfile_DeveSerValido()
    {   
        // Arrange & Act
        var configuration = new MapperConfiguration(p => p.AddProfile<PresentationProfile>());

        // Assert
        configuration.AssertConfigurationIsValid();
    }
}